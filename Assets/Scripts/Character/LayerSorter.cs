using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour {

    private int defaultSortingOrder;
    private List<Obstacle> obstacles = new List<Obstacle>();
    
    void Start() {
        this.defaultSortingOrder = this.transform.parent.GetComponent<SpriteRenderer>().sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Obstacle") {
            
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            obstacle.FadeOut();

            SpriteRenderer parentRenderer = this.transform.parent.GetComponent<SpriteRenderer>();
            if (this.obstacles.Count == 0 || obstacle.ObstacleRenderer.sortingOrder - 1 < parentRenderer.sortingOrder) {
                parentRenderer.sortingOrder = obstacle.ObstacleRenderer.sortingOrder - 1;
            }

            this.obstacles.Add(obstacle);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Obstacle") {

            Obstacle obstacle = collision.GetComponent<Obstacle>();
            this.obstacles.Remove(obstacle);
            obstacle.FadeIn();

            SpriteRenderer parentRenderer = this.transform.parent.GetComponent<SpriteRenderer>();
            if (this.obstacles.Count == 0) {
                parentRenderer.sortingOrder = this.defaultSortingOrder;
            } else {
                this.obstacles.Sort();
                parentRenderer.sortingOrder = this.obstacles[0].ObstacleRenderer.sortingOrder - 1;
            }
        }
    }
}

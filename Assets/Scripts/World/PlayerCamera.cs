using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCamera : MonoBehaviour {

    private Transform target;
    private float xMin, xMax, yMin, yMax;

    [SerializeField]
    private Tilemap tilemap = null;
    
    private Player player;

    void Start() {
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        this.player = this.target.GetComponent<Player>();

        Vector3 minTile = this.tilemap.CellToWorld(this.tilemap.cellBounds.min);
        Vector3 maxTile = this.tilemap.CellToWorld(this.tilemap.cellBounds.max);

        this.SetLimits(minTile, maxTile);
        this.player.SetLimits(minTile, maxTile);
    }

    void LateUpdate() {
        this.transform.position = new Vector3(Mathf.Clamp(this.target.position.x, this.xMin, this.xMax), Mathf.Clamp(this.target.position.y, this.yMin, this.yMax), -10);
    }

    private void SetLimits(Vector3 minTile, Vector3 maxTile) {
        Camera camera = Camera.main;

        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;

        this.xMin = minTile.x + width / 2;
        this.xMax = maxTile.x - width / 2;

        this.yMin = minTile.y + height / 2;
        this.yMax = maxTile.y - height / 2;
    }
}
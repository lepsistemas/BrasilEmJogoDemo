using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    [SerializeField]
    ItemScriptable info;

    [SerializeField]
    SpriteRenderer ItemSprite;

    void Start()
    {
        ItemSprite.sprite = info.itemSprite;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Player")
        {
            InventoryManager.Instance.AddItem(info);
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFarinaController : MonoBehaviour
{

    public GameObject[] ItemAnchor;    

    void Start()
    {
        Clear();
    }

    public void LoadItem(int _item)
    {
        Clear();
        ItemAnchor[_item].SetActive(true);
    }

    public void DisableItem()
    {
        Clear();
    }

    public void Clear()
    {
        foreach (GameObject g in ItemAnchor)
        {
            g.SetActive(false);
        }
    }



}

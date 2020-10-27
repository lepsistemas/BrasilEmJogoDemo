using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    RectTransform rectTransform;

    [SerializeField]
    int itemId;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void PointerEnter()
    {
        rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void PointerExit()
    {
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }   

}

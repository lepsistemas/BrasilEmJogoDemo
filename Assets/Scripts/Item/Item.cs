using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemScriptable itemInfo { get; set; }

    public Item(ItemScriptable _item)
    {
        itemInfo = _item;
    }   
}

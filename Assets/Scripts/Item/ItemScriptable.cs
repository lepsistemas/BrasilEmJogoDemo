using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Leandro/Item", order = 1)]
public class ItemScriptable : ScriptableObject
{
    public int itemId;
    public string itemName;
    public Sprite itemSprite;
    public int itemPrice;
    public ItemType itemType;
}

public enum ItemType
{
    Equip,
    Consumable
}

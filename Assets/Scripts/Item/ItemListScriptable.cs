using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Leandro/ItemiList", order = 2)]
public class ItemListScriptable : ScriptableObject
{
    public List<ItemScriptable> ItemList = new List<ItemScriptable>();
}

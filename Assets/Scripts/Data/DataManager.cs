using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    [SerializeField]
    ItemListScriptable itemList;

    [SerializeField]
    CharacterInfo characterInfo;

    public void SaveItemList(List<Item> itemList)
    {
        for (int i = 0; i < 12; i++)
        {
            if (i < itemList.Count)
            {
                PlayerPrefs.SetInt( "item" + i.ToString(), itemList[i].itemInfo.itemId ) ;
            }
            else
            {
                PlayerPrefs.SetInt( "item" + i.ToString(), 0);
            }
        }
    }

    public void LoadItemList()
    {
        for (int i = 0; i < 12; i++)
        {
            if (PlayerPrefs.HasKey("item" + i.ToString()) == true)
            {
                int item = PlayerPrefs.GetInt("item" + i.ToString());

                if (item > 0)
                {
                    characterInfo.AddItemByDB(this.itemList.ItemList[item]);
                }
            }            
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        characterInfo.ClearItemList();
    }
}

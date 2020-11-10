using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{

    public static CharacterInfo Instance;

    [SerializeField]
    DataManager Data;

    public string CharacterName { get; set; }
    public int CharacterId { get; set; }

    public int CharacterCash { get; set; }

    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }

    [HideInInspector]
    public List<Item> playerItemList = new List<Item>();

    [SerializeField]
    ItemListScriptable itemList;

    [SerializeField]
    ItemScriptable[] InitialItemList;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }        
    }

    void Start()
    {
        CheckData();
    }

    void CheckData()
    {
        if (PlayerPrefs.HasKey("first") == false)
        {
            foreach (ItemScriptable i in InitialItemList)
            {
                AddItem(i);
            }

            PlayerPrefs.SetInt("first", 0);
        }
        else
        {
            Data.LoadItemList();
        }
    }

    public void AddItem(ItemScriptable _item)
    {
        playerItemList.Add(new Item(_item));
        SaveItemList();
    }

    public void AddItemByDB(ItemScriptable _item)
    {
        playerItemList.Add(new Item(_item));
    }

    public void RemoveItem(int itemId )
    {
        playerItemList.RemoveAt(itemId);
        SaveItemList();
    }

    public void SaveItemList()
    {
        Data.SaveItemList(playerItemList);
    }

    public void ClearItemList()
    {
        playerItemList.Clear();
        CheckData();
    }

}

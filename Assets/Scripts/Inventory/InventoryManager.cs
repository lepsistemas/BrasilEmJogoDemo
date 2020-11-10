using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;

    public delegate void UseItem(int _item);
    public static UseItem OnUseItem;

    CharacterInfo characterInfo;

    [SerializeField]
    GameObject inventoryUi;

    [SerializeField]
    GameObject[] slots;

    [SerializeField]
    GameObject ItemActionAnchor;

    [SerializeField]
    Image ItemActionSprite;

    [SerializeField]
    Text ItemActionText;

    int SelecteditmId;    

    [SerializeField]
    Text PlayerCash;

    [SerializeField]
    ItemListScriptable scriptableList;

    [SerializeField]
    ItemScriptable[] initialItemList;

    [SerializeField]
    Sprite emptySlotSprite;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ItemActionAnchor.SetActive(false);

        characterInfo = CharacterInfo.Instance;

        for (int i = 0; i < initialItemList.Length; i++)
        {
            //itemList.Add(new Item(initialItemList[i]));
        }

        Mountinventory();
    }

    public void AddItemByDB(ItemScriptable _item)
    {
        characterInfo.AddItem(_item);
        Mountinventory();
    }

    public void AddItem(ItemScriptable _item)
    {
        characterInfo.AddItem(_item);
        Mountinventory();        
    }

    void Mountinventory()
    {
        ClearSlots();

        for (int i = 0; i < characterInfo.playerItemList.Count; i++)
        {
            slots[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = characterInfo.playerItemList[i].itemInfo.itemSprite;
        }
    }

    void ClearSlots()
    {
        foreach (GameObject g in slots)
        {
            g.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = emptySlotSprite;
        }
    }

    public void Show()
    {
        if(inventoryUi.activeSelf == false)
        {
            Mountinventory();
            //PlayerCash.text = characterInfo.CharacterCash.ToString();
            inventoryUi.SetActive(true);
        }
        else
        {
            inventoryUi.SetActive(false);
        }

        
    }

    public void Hide()
    {
        inventoryUi.SetActive(false);
    }

    public void ClickOnItem(int _item)
    {
        SelecteditmId = _item;
        ItemActionSprite.sprite = characterInfo.playerItemList[_item].itemInfo.itemSprite;
        ItemActionText.text = characterInfo.playerItemList[_item].itemInfo.itemName;
        ItemActionAnchor.SetActive(true);
    }

    public void ActionItem()
    {
        if (OnUseItem != null)
            OnUseItem(characterInfo.playerItemList[SelecteditmId].itemInfo.itemId);

        //itemList.RemoveAt(SelecteditwmId);
        inventoryUi.SetActive(false);
        ItemActionAnchor.SetActive(false);
    }

    public void SelectItem(int _item)
    {
        SelecteditmId = _item;
    }

    public void DeleteItem()
    {
        characterInfo.RemoveItem(SelecteditmId);
        Mountinventory();
        ItemActionAnchor.SetActive(false);        
    }

    public void Close()
    {
        ItemActionAnchor.SetActive(false);
    }

   

    public void RemoveItem(int itemId)
    {
        int selectedId = -1;
        for (int i = 0; i < characterInfo.playerItemList.Count; i++)
        {
            if (characterInfo.playerItemList[i].itemInfo.itemId == itemId)
            {
                selectedId = i;
                break;
            }
        }
        if (selectedId != -1) {
            characterInfo.playerItemList.RemoveAt(selectedId);
        }
    }

    public int GetItemListCount()
    {
        return characterInfo.playerItemList.Count;
    }


}

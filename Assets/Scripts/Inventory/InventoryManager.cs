using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;

    public delegate void LoadItem(int _item);
    public static LoadItem OnUseItem;

    public delegate void OfertItem(int _item);
    public static OfertItem OnOfertItem;

    public delegate void TakeBackItem();
    public static TakeBackItem OnTakeBackItem;

    CharacterInfo characterInfo;

    List<Item> itemList = new List<Item>();

    [SerializeField]
    GameObject inventoryUi;

    [SerializeField]
    GameObject[] slots;

    [SerializeField]
    GameObject ItemActionAnchor;

    int SelecteditwmId;

    [SerializeField]
    Image ItemActionSprite;

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
        StartCoroutine(ShowWorld());
        //characterInfo = CharacterInfo.Instance;
        //inventoryUi.SetActive(false);
        //ItemActionAnchor.SetActive(false);

        for (int i = 0; i < initialItemList.Length; i++)
        {
            itemList.Add(new Item(initialItemList[i]));
        }

        Mountinventory();


    }

    public void AddItemByDB(ItemScriptable _item)
    {
        //Debug.Log("AddItem(ItemFarinaScriptable _item)");
        itemList.Add(new Item(_item));
        Mountinventory();
    }

    public void AddItem(ItemScriptable _item)
    {
        //Debug.Log("AddItem(ItemFarinaScriptable _item)");
        itemList.Add(new Item(_item));
        Mountinventory();
        //StartCoroutine(SaveInventory());
    }

    void Mountinventory()
    {
        ClearSlots();

        for (int i = 0; i < itemList.Count; i++)
        {
            slots[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = itemList[i].itemInfo.itemSprite;
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
        Mountinventory();
        //PlayerCash.text = characterInfo.CharacterCash.ToString();
        inventoryUi.SetActive(true);
    }

    public void Hide()
    {
        inventoryUi.SetActive(false);
    }

    public void ClickOnItem(int _item)
    {
        SelecteditwmId = _item;
        ItemActionSprite.sprite = itemList[_item].itemInfo.itemSprite;
        ItemActionAnchor.SetActive(true);
    }

    public void UseItem()
    {
        if (OnUseItem != null)
            OnUseItem(itemList[SelecteditwmId].itemInfo.itemId);

        //itemList.RemoveAt(SelecteditwmId);
        inventoryUi.SetActive(false);
        ItemActionAnchor.SetActive(false);
    }

    public void SelectItem(int _item) {
        SelecteditwmId = _item;
    }

    public void DeselectUsedItem() {
        OnUseItem(-1);
    }

    public void OfertarItem()
    {
        if (OnOfertItem != null)
            OnOfertItem(itemList[SelecteditwmId].itemInfo.itemId);

        itemList.RemoveAt(SelecteditwmId);
        inventoryUi.SetActive(false);
        ItemActionAnchor.SetActive(false);
    }

    public void DeleteItem()
    {
        itemList.RemoveAt(SelecteditwmId);
        inventoryUi.SetActive(false);
        ItemActionAnchor.SetActive(false);
        //StartCoroutine(SaveInventory());
    }

    public void Close()
    {
        ItemActionAnchor.SetActive(false);
    }

    public bool CheckItem(int itemId)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemInfo.itemId == itemId)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(int itemId)
    {
        int selectedId = -1;
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemInfo.itemId == itemId)
            {
                selectedId = i;
                break;
            }
        }
        if (selectedId != -1) {
            itemList.RemoveAt(selectedId);
        }
    }

    public int GetItemListCount()
    {
        return itemList.Count;
    }


    IEnumerator ShowWorld()
    {
        yield return new WaitForSeconds(2);
        show = true;
    }

    bool show = false;
    [SerializeField]
    Image LoadImage;

    float timer;

    /*/void Update()
    {
        if(show == true)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer * 1);
            timer += Time.deltaTime;
            // I'll guess the script is attached to the object you want to fade out, and that you have the appropriate shader.
            LoadImage.color = new Color(255, 255, 255, alpha);

            if (alpha == 0)
            {
                Destroy(LoadImage.gameObject);
                show = false;
            }
        }
    }/*/
}

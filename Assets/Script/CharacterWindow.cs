using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterWindow : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Text text;

    [SerializeField] GameObject ItemTextPrefab;
    // Parent transforms of trade window grids
    [Tooltip("Transform of parent grid object for trading")]
    [SerializeField] Transform tradeNPCGrid;
    [Tooltip("Transform of parent grid object for trading")]
    [SerializeField] Transform tradeNegotiationGrid;
    [Tooltip("Transform of parent grid object for trading")]
    [SerializeField] Transform tradePlayerGrid;
    //The Items slots selected in each window of the Trade Menu
    private ItemSlot selectedNPCItemSlot;
    private ItemSlot selectedNegotiationItemSlot;
    private ItemSlot selectedPlayerItemSlot;

    //List for temporarily holding copies of inventories
    private List<ItemSlot> inventoryNPC = new List<ItemSlot>();
    private List<ItemSlot> inventoryPlayer = new List<ItemSlot>();
    //2 lists for trade window for the sake of dividing asks and offers 
    private List<ItemSlot> askList = new List<ItemSlot>();
    private List<ItemSlot> offerList = new List<ItemSlot>();

    void Start()
    {
        EventManager.Subscribe("MouseClickNPCItem", ItemSelectedNPC);
        EventManager.Subscribe("MouseClickNegotiationItem", ItemSelectedNegotiation);
        EventManager.Subscribe("MouseClickPlayerItem", ItemSelectedPlayer);
    }
    public void CharacterSelected(Character character)//resets all the 
    {
        inventoryNPC = character.inventory._items;
        inventoryPlayer = PlayerInfo.inventory._items;
        askList = new List<ItemSlot>();
        offerList = new List<ItemSlot>();

        ResetOfferWindow();
        ResetNPCInventoryWindow();
        ResetPlayerInventoryWindow();
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseClickNPCItem", ItemSelectedNPC);
        EventManager.UnSubscribe("MouseClickNegotiationItem", ItemSelectedNegotiation);
        EventManager.UnSubscribe("MouseClickPlayerItem", ItemSelectedPlayer);
    }

    void ItemSelectedNPC(EventParameter eventParam)
    {
        selectedNPCItemSlot = eventParam.itemSlotParam;
    }
    void ItemSelectedNegotiation(EventParameter eventParam)
    {
        selectedNegotiationItemSlot = eventParam.itemSlotParam;
    }
    void ItemSelectedPlayer(EventParameter eventParam)
    {
        selectedPlayerItemSlot = eventParam.itemSlotParam;
    }

    public void addAsk()
    {
        ItemSlot slot = GetItemSlot(selectedNPCItemSlot._item, askList);
        if (slot._amount == 0)
        {
            askList.Add(slot);
        }
        slot._amount += 1;
        ResetOfferWindow();

    }

    public void addOffer()
    {
        ItemSlot slot = GetItemSlot(selectedPlayerItemSlot._item, offerList);
        if (slot._amount == 0)
        {
            offerList.Add(slot);
        }
        slot._amount += 1;
        ResetOfferWindow();
    }

    ItemSlot GetItemSlot(Item item, List<ItemSlot> itemList)
    {
        foreach (ItemSlot buySlot in itemList)
        {
            if (buySlot._item.name == item.name)
            {
                return buySlot;
            }
        }
        ItemSlot emptySlot = new ItemSlot() { _item = item, _amount = 0 };
        return emptySlot;
    }

    public void ResetOfferWindow()
    {
        foreach (Transform child in tradeNegotiationGrid) //Tar bort alla object från menyn
        {
            Destroy(child.gameObject);
        }
        foreach (ItemSlot item in askList) //Skapar nya object för varje objekt typ
        {
            GameObject gObject = Instantiate(ItemTextPrefab, tradeNegotiationGrid);
            gObject.GetComponent<ButtonNegotiationItem>().enabled = true;
            gObject.GetComponent<ButtonNegotiationItem>().item = item;
            gObject.GetComponent<ButtonNegotiationItem>().SetColour();

        }
        foreach (ItemSlot item in offerList) //Skapar nya object för varje objekt typ
        {
            GameObject gObject = Instantiate(ItemTextPrefab, tradeNegotiationGrid);
            gObject.GetComponent<ButtonNegotiationItem>().enabled = true;
            gObject.GetComponent<ButtonNegotiationItem>().item = item;
        }
        selectedNegotiationItemSlot = null;
    }

    public void ResetNPCInventoryWindow()
    {
        foreach (Transform child in tradeNPCGrid) //Tar bort alla object från menyn
        {
            Destroy(child.gameObject);
        }
        foreach (ItemSlot item in inventoryNPC) //Skapar nya object för varje objekt typ
        {
            GameObject gObject = Instantiate(ItemTextPrefab, tradeNPCGrid);
            gObject.GetComponent<ButtonNPCItemButton>().enabled = true;
            gObject.GetComponent<ButtonNPCItemButton>().item = item;
        }
        selectedNPCItemSlot = null;
    }

    public void ResetPlayerInventoryWindow()
    {
        foreach (Transform child in tradePlayerGrid) //Tar bort alla object från menyn
        {
            Destroy(child.gameObject);
        }
        foreach (ItemSlot item in inventoryPlayer) //Skapar nya object för varje objekt typ
        {
            GameObject gObject = Instantiate(ItemTextPrefab, tradePlayerGrid);
            gObject.GetComponent<ButtonPlayerItem>().enabled = true;
            gObject.GetComponent<ButtonPlayerItem>().item = item;
        }
        selectedPlayerItemSlot = null;
    }

    public void OfferTrade()
    {
        int price = 0;
        foreach (ItemSlot item in askList)
        {
            price -= item._value;
        }
        foreach (ItemSlot item in offerList)
        {
            price -= item._value;
        }

    }
}

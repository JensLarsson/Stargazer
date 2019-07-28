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

    private Character _character;
    //List for temporarily holding copies of inventories
    private Inventory inventoryNPC = new Inventory();
    private Inventory inventoryPlayer = new Inventory();
    //2 lists for trade window for the sake of dividing asks and offers 
    private Inventory askList = new Inventory();
    private Inventory offerList = new Inventory();

    void Start()
    {
        EventManager.Subscribe("MouseClickNPCItem", ItemSelectedNPC);
        EventManager.Subscribe("SoldOutItem", ItemSoldOut);
        EventManager.Subscribe("SoldOutItemPlayer", ItemSoldOutPlayer);
        EventManager.Subscribe("SoldOutItemNegotiation", ItemSoldOutNegotiation);
        EventManager.Subscribe("MouseClickNegotiationItem", ItemSelectedNegotiation);
        EventManager.Subscribe("MouseClickPlayerItem", ItemSelectedPlayer);
    }
    public void CharacterSelected(Character character)//resets all the 
    {
        if (_character != null)
        {
            PlayerInfo.inventory.AddItem(offerList._items);
            _character.inventory.AddItem(askList._items);
        }
        _character = character;
        inventoryNPC = character.inventory;
        inventoryPlayer = PlayerInfo.inventory;
        askList = new Inventory();
        offerList = new Inventory();

        ResetOfferWindow();
        ResetNPCInventoryWindow();
        ResetPlayerInventoryWindow();

    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseClickNPCItem", ItemSelectedNPC);
        EventManager.UnSubscribe("SoldOutItem", ItemSoldOut);
        EventManager.UnSubscribe("SoldOutItemPlayer", ItemSoldOutPlayer);
        EventManager.UnSubscribe("SoldOutItemNegotiation", ItemSoldOutNegotiation);
        EventManager.UnSubscribe("MouseClickNegotiationItem", ItemSelectedNegotiation);
        EventManager.UnSubscribe("MouseClickPlayerItem", ItemSelectedPlayer);

        PlayerInfo.inventory.AddItem(offerList._items);
        _character.inventory.AddItem(askList._items);
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
        ItemSlot slot = GetItemSlot(selectedNPCItemSlot._item, offerList._items);
        EventParameter eventParam = new EventParameter()
        {
            itemParam = slot._item
        };
        if (slot._amount > 0)
        {
            offerList.AddItem(slot._item, -1);
            inventoryPlayer.AddItem(slot._item, 1);
            EventManager.TriggerEvent("ItemPurchased", eventParam);
            ResetPlayerInventoryWindow();
            return;
        }
        slot = GetItemSlot(selectedNPCItemSlot._item, askList._items);
        if (slot._amount == 0)
        {
            askList._items.Add(slot);
        }
        slot._amount += 1;
        inventoryNPC.AddItem(slot._item, -1);
        ResetOfferWindow();
        EventManager.TriggerEvent("ItemPurchased", eventParam);
    }

    public void addOffer()
    {
        ItemSlot slot = GetItemSlot(selectedPlayerItemSlot._item, askList._items);
        EventParameter eventParam = new EventParameter()
        {
            itemParam = slot._item
        };

        if (slot._amount > 0)
        {
            askList.AddItem(slot._item, -1);
            inventoryNPC.AddItem(slot._item, 1);
            EventManager.TriggerEvent("ItemPurchased", eventParam);
            ResetNPCInventoryWindow();
            return;
        }

        slot = GetItemSlot(selectedPlayerItemSlot._item, offerList._items);
        if (slot._amount == 0)
        {
            offerList._items.Add(slot);
        }
        slot._amount += 1;
        ResetOfferWindow();
        PlayerInfo.inventory.AddItem(slot._item, -1);
        EventManager.TriggerEvent("ItemPurchased", eventParam);
    }

    ItemSlot GetItemSlot(Item item, List<ItemSlot> itemList)
    {
        foreach (ItemSlot buySlot in itemList)
        {
            if (buySlot._item.name == item.name && buySlot._item.material == item.material)
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
        foreach (ItemSlot item in askList._items) //Skapar nya object för varje objekt typ
        {
            GameObject gObject = Instantiate(ItemTextPrefab, tradeNegotiationGrid);
            gObject.GetComponent<ButtonNegotiationItem>().enabled = true;
            gObject.GetComponent<ButtonNegotiationItem>().item = item;
            gObject.GetComponent<ButtonNegotiationItem>().SetColour();
        }
        foreach (ItemSlot item in offerList._items) //Skapar nya object för varje objekt typ
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
        foreach (ItemSlot item in inventoryNPC._items) //Skapar nya object för varje objekt typ
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
        foreach (ItemSlot item in inventoryPlayer._items) //Skapar nya object för varje objekt typ
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
        foreach (ItemSlot item in askList._items)
        {
            price -= item._value;
        }
        foreach (ItemSlot item in offerList._items)
        {
            price -= item._value;
        }
        if (PlayerInfo.Pay(price))
        {
            inventoryPlayer.AddItem(askList._items);
            inventoryNPC.AddItem(offerList._items);
            askList = new Inventory();
            offerList = new Inventory();
            ResetOfferWindow();
            ResetNPCInventoryWindow();
            ResetPlayerInventoryWindow();
        }
    }

    public void RemoveNegotiatedItem()
    {
        EventParameter eventParam = new EventParameter()
        {
            itemParam = selectedNegotiationItemSlot._item
        };
        foreach (ItemSlot slot in askList._items)
        {
            if (slot._item.name == selectedNegotiationItemSlot._item.name)
            {
                askList.AddItem(slot._item, -1);
                inventoryNPC.AddItem(slot._item, 1);
                EventManager.TriggerEvent("ItemPurchased", eventParam);
                ResetNPCInventoryWindow();
                return;
            }
        }
        foreach (ItemSlot slot in offerList._items)
        {
            if (slot._item.name == selectedNegotiationItemSlot._item.name)
            {
                offerList.AddItem(slot._item, -1);
                inventoryPlayer.AddItem(slot._item, 1);
                EventManager.TriggerEvent("ItemPurchased", eventParam);
                ResetPlayerInventoryWindow();
                return;
            }
        }
    }

    void ItemSoldOut(EventParameter eventParam)
    {
        ResetNPCInventoryWindow();
    }

    void ItemSoldOutPlayer(EventParameter eventParam)
    {
        ResetPlayerInventoryWindow();
    }
    void ItemSoldOutNegotiation(EventParameter eventParam)
    {
        ResetOfferWindow();
    }
}

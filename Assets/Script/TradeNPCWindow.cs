using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeNPCWindow : MonoBehaviour
{

    public Transform parentTransform;
    public GameObject textPrefab;
    Character character;
    ItemSlot itemSlot;
    List<ItemSlot> items;

    void Start()
    {
        EventManager.Subscribe("MouseClickNPCItem", ItemSelected);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseClickNPCItem", ItemSelected);
    }

    void ResetCharacterItemMenu(EventParameter eventParam)
    {
        character = eventParam.characterParam;
        foreach (Transform child in parentTransform) //Tar bort alla object från menyn
        {
            Destroy(child.gameObject);
        }
        foreach (ItemSlot item in eventParam.characterParam.inventory._items) //Skapar nya object för varje objekt typ
        {
            GameObject gObject = Instantiate(textPrefab, parentTransform);
            gObject.GetComponent<ButtonNPCItemButton>().item = item;
        }
        itemSlot = null;
    }
    public void ResetCharacterItemMenu()
    {
        foreach (Transform child in parentTransform) //Tar bort alla object från menyn
        {
            Destroy(child.gameObject);
        }
        foreach (ItemSlot item in items) //Skapar nya object för varje objekt typ
        {
            GameObject gObject = Instantiate(textPrefab, parentTransform);
            gObject.GetComponent<ButtonNPCItemButton>().item = item;
        }
        itemSlot = null;
    }
    //Nollställer listan, genom att ta bort alla objekt
    void ClearItemMenu()
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
        character = null; //Då inga objekt visas, så antas att ingen karaktär är vald
        itemSlot = null;
    }

    void ItemSelected(EventParameter eventParam)
    {
        itemSlot = eventParam.itemSlotParam;
    }

    public void PurchaseSelectedItem()
    {
            PlayerInfo.inventory.AddItem(itemSlot._item);
            character.inventory.AddItem(itemSlot._item, -1);
            Debug.Log(PlayerInfo.inventory._items.Count);
            EventParameter eventParam = new EventParameter() { itemParam = itemSlot._item };
            EventManager.TriggerEvent("ItemPurchased", eventParam);
        
    }
}


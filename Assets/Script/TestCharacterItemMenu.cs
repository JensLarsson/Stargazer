using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterItemMenu : MonoBehaviour
{

    public Transform parentTransform;
    public GameObject textPrefab;
    Character character;
    ItemSlot itemSlot;
    void Start()
    {
        EventManager.Subscribe("MouseClickCharacter", ResetCharacterItemMenu);
        EventManager.Subscribe("MouseDownLocation", ClearItemMenu);
        EventManager.Subscribe("MouseClickNPCItem", ItemSelected);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseClickCharacter", ResetCharacterItemMenu);
        EventManager.UnSubscribe("MouseDownLocation", ClearItemMenu);
        EventManager.UnSubscribe("MouseClickNPCItem", ItemSelected);
    }


    void ResetCharacterItemMenu(EventParameter eventParam)
    {
        character = eventParam.characterParam;
        foreach (Transform child in parentTransform) //Tar bort alla object från menyn
        {
            Destroy(child.gameObject);
        }
        foreach (ItemSlot item in eventParam.characterParam.inventory.items) //Skapar nya object för varje objekt typ
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
        foreach (ItemSlot item in character.inventory.items) //Skapar nya object för varje objekt typ
        {
            GameObject gObject = Instantiate(textPrefab, parentTransform);
            gObject.GetComponent<ButtonNPCItemButton>().item = item;
        }
        itemSlot = null;
    }
    //Nollställer listan, genom att ta bort alla objekt
    void ClearItemMenu(EventParameter eventParam)
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
        if (PlayerInfo.Pay(itemSlot._value))
        {
            PlayerInfo.inventory.AddItem(itemSlot._item);
            character.inventory.AddItem(itemSlot._item, -1);
        }
    }
}

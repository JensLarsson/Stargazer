using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public Item _item;
    public int _amount = 0;
    public int _value = 10;
}

[System.Serializable]
public class Inventory
{
    public List<ItemSlot> items = new List<ItemSlot>();


    public void GenerateNewInventory(int amount)
    {
        itemLibrary itL = new itemLibrary();
        JSONserializer json = new JSONserializer();
        List<Item> itemLib = json.LoadItemLibrary(); //The list of all available items in the game, this should be moved somewhere where it won't be reloaded repeatedly

        int libraryLength = itemLib.Count;
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, libraryLength);
            AddItem(itemLib[index]);
        }
    }

    public int CountItem(Item item)
    {
        return getItem(item)._amount;
    }

    public void AddItem(Item item)
    {
        ItemSlot slot = getItem(item);
        if (slot._amount == 0)
        {
            items.Add(slot);
        }
        slot._amount += 1;
    }
    public void AddItem(Item item, int amount)
    {
        ItemSlot slot = getItem(item);
        if (slot._amount == 0)
        {
            items.Add(slot);
        }
        slot._amount += amount;
    }

    ItemSlot getItem(Item item)
    {
        foreach (ItemSlot iS in items)
        {
            if (iS._item.name == item.name)
            {
                return iS;
            }
        }
        ItemSlot emptySlot = new ItemSlot() { _item = item, _amount = 0 };
        return emptySlot;
    }
}

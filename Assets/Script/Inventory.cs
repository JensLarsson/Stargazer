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
    public List<ItemSlot> _items = new List<ItemSlot>();


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
        return GetItemSlot(item)._amount;
    }
    public void AddItem(List<ItemSlot> items)
    {
        foreach (ItemSlot slot in items)
        {
            bool found = false;
            foreach (ItemSlot _slot in _items)
            {
                if (slot._item.name == _slot._item.name)
                {
                    found = true;
                    _slot._amount += slot._amount;
                    break;
                }
            }
            if (!found)
            {
                _items.Add(slot);////Fix shit here
            }
        }

    }
    public void RemoveItems(List<ItemSlot> items)
    {
        foreach (ItemSlot slot in items)
        {
            foreach (ItemSlot _slot in _items)
            {
                if (slot._item.name == _slot._item.name)
                {
                    _slot._amount -= slot._amount;
                    break;
                }
            }
        }
    }
    public void AddItem(Item item)
    {
        ItemSlot slot = GetItemSlot(item);
        if (slot._amount == 0)
        {
            _items.Add(slot);
        }
        slot._amount += 1;
    }
    public void AddItem(Item item, int amount)
    {
        ItemSlot slot = GetItemSlot(item);
        if (slot._amount == 0)
        {
            _items.Add(slot);
        }
        slot._amount += amount;
        if (slot._amount <= 0)
        {
            RemoveItem(slot._item);
        }
    }

    ItemSlot GetItemSlot(Item item)
    {
        foreach (ItemSlot iS in _items)
        {
            if (iS._item.name == item.name)
            {
                return iS;
            }
        }
        ItemSlot emptySlot = new ItemSlot() { _item = item, _amount = 0 };
        return emptySlot;
    }

    void RemoveItem(Item item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i]._item.name == item.name)
            {
                _items.RemoveAt(i);
            }
        }
    }
}

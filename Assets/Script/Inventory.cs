using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        foreach (ItemSlot item in items)
        {
            ItemSlot slot = GetItemSlot(item._item);
            if (slot._amount == 0)
            {
                _items.Add(slot);
            }
            slot._amount += item._amount;
            if (slot._amount <= 0)
            {
                RemoveItem(slot._item);
            }
            //bool found = false;
            //foreach (ItemSlot _slot in _items)
            //{
            //    if (item._item.name == _slot._item.name && item._item.material == _slot._item.material)
            //    {
            //        found = true;
            //        _slot._amount += item._amount;
            //        break;
            //    }
            //}
            //if (!found)
            //{
            //    _items.Add(item);////Fix shit here
            //}
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
            if (iS._item.name == item.name && iS._item.material == item.material)
            {
                return iS;
            }
        }
        ItemMaterial itemMaterial = new ItemMaterial();
        ItemSlot emptySlot = new ItemSlot() { _item = item, _amount = 0 };
        return emptySlot;
    }

    void RemoveItem(Item item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i]._item.name == item.name && item.material == _items[i]._item.material)
            {
                _items.RemoveAt(i);
            }
        }
    }

    public bool HasItems(List<ItemSlot> items)
    {
        foreach (ItemSlot iSlot in items)
        {
            ItemSlot inventorySlot = GetItemSlot(iSlot._item); // Returns the slot in this.inventory
            if (inventorySlot._amount < iSlot._amount) //Compares the amount of items in the slot returned in previous row
            {
                return false;
            }
        }
        return true;
    }
}

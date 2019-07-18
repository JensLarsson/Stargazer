using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public Item _item;
    public int _amount = 0;
}

[System.Serializable]
public class Inventory
{
    List<ItemSlot> items = new List<ItemSlot>();

    public List<ItemSlot> Items
    {
        get
        {
            return items;
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

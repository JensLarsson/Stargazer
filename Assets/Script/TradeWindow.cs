using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeWindow : MonoBehaviour
{
    public List<ItemSlot> buyList = new List<ItemSlot>();
    public List<ItemSlot> sellList = new List<ItemSlot>();

    public Transform parentTransform;
    public GameObject textPrefab;
    Character character;
    ItemSlot itemSlot;


    public void AddBuy(Item item)
    {
        ItemSlot slot = GetItem(item, true);
        if (slot._amount == 0)
        {
            buyList.Add(slot);
        }
        slot._amount += 1;
    }
    public void AddSell(Item item)
    {
        ItemSlot slot = GetItem(item, false);
        if (slot._amount == 0)
        {
            sellList.Add(slot);
        }
        slot._amount += 1;
    }

    ItemSlot GetItem(Item item, bool fromBuy = false)
    {
        if (fromBuy)
        {//Returns slot from buylist if it exists
            foreach (ItemSlot buySlot in buyList)
            {
                if (buySlot._item.name == item.name)
                {
                    return buySlot;
                }
            }
        }
        else
        {//Returns slot from sellList if it exists
            foreach (ItemSlot sellSlot in sellList)
            {
                if (sellSlot._item.name == item.name)
                {
                    return sellSlot;
                }
            }
        }
        ItemSlot emptySlot = new ItemSlot() { _item = item, _amount = 0 };
        return emptySlot;
    }
}

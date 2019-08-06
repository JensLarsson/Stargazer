using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public Item _item;
    public int _amount = 0;
    public int _value = 10;

    public string GetContent()
    {
        return _item.name + " x " + _amount.ToString();
    }

    public string GetItemName()
    {
        return _item.material.ToString() + " " + _item.name;
    }
}
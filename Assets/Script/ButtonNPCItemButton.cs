﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonNPCItemButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public Text text;
    [System.NonSerialized] public ItemSlot item;
    Image image;
    bool selected = false;

    private void Start()
    {
        image = GetComponent<Image>();
        text.text = item._item.material.ToString() + " " + item._item.name + " x" + item._amount.ToString();
        EventManager.Subscribe("MouseClickNPCItem", MouseClick);
        EventManager.Subscribe("ItemPurchased", RefreshText);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseClickNPCItem", MouseClick);
        EventManager.UnSubscribe("ItemPurchased", RefreshText);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EventParameter eventParam = new EventParameter() { itemSlotParam = item };
        EventManager.TriggerEvent("MouseClickNPCItem", eventParam);
        selected = true;
        Color colour = image.color;
        colour.a = 100;
        image.color = colour;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventParameter eventParam = new EventParameter() { };
        Color colour = image.color;
        colour.a = 100;
        image.color = colour;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!selected)
        {
            Color colour = image.color;
            colour.a = 0;
            image.color = colour;
        }
    }

    void MouseClick(EventParameter eventParam)
    {
        selected = false;
        Color colour = image.color;
        colour.a = 0;
        image.color = colour;
    }

    void RefreshText(EventParameter eventParam)
    {
        text.text = item._item.material.ToString() + " " + item._item.name + " x" + item._amount.ToString();

        if (item._amount <= 0)
        {
            EventManager.TriggerEvent("SoldOutItem", eventParam);
        }
    }
}

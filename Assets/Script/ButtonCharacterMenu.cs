using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonCharacterMenu : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public Text text;
    [System.NonSerialized] public Character character;
    Image image;
    bool selected = false;

    private void Start()
    {
        image = GetComponent<Image>();
        text.text = character.name;
        EventManager.Subscribe("MouseClickCharacter", MouseClick);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseClickCharacter", MouseClick);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EventParameter eventParam = new EventParameter() { characterParam = character };
        EventManager.TriggerEvent("MouseClickCharacter", eventParam);
        selected = true;
        Color colour = image.color;
        colour.a = 100;
        image.color = colour;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventParameter eventParam = new EventParameter() { characterParam = character };
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
    
}

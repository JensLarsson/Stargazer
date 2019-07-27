using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCharacterMenu : MonoBehaviour
{

    [SerializeField] Transform parentTransform;
    [SerializeField] GameObject textPrefab;
    [SerializeField] CharacterWindow CharacterWindow;
    void Start()
    {
        EventManager.Subscribe("MouseDownLocation", ResetCharacterMenu);
        EventManager.Subscribe("MouseClickCharacter", CharacterSelected);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseDownLocation", ResetCharacterMenu);
        EventManager.UnSubscribe("MouseClickCharacter", CharacterSelected);
    }
    //Reset list of characters and hides character window
    void ResetCharacterMenu(EventParameter eventParam)
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (Character character in eventParam.locationParam.characters)
        {
            GameObject gObject = Instantiate(textPrefab, parentTransform);
            gObject.GetComponent<ButtonCharacterMenu>().character = character;
        }
        CharacterWindow.gameObject.SetActive(false); //hide window
    }
    //Set up Character window with the information of the selected character
    void CharacterSelected(EventParameter eventParam)
    {
        CharacterWindow.gameObject.SetActive(true);
        CharacterWindow.CharacterSelected(eventParam.characterParam);
    }
}

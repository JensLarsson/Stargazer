using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCharacterMenu : MonoBehaviour
{

    public Transform parentTransform;
    public Text textPrefab;
    void Start()
    {
        EventManager.Subscribe("MouseDownLocation", ResetCharacterMenu);

    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseDownLocation", ResetCharacterMenu);
    }

    void ResetCharacterMenu(EventParameter eventParam)
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (Character character in eventParam.locationParam.characters)
        {
            GameObject gObject = Instantiate(textPrefab.gameObject, parentTransform);
            gObject.GetComponent<Text>().text = character.name;
        }
    }
}

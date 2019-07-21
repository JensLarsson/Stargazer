using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterItemMenu : MonoBehaviour
{

    public Transform parentTransform;
    public GameObject textPrefab;
    void Start()
    {
        EventManager.Subscribe("MouseClickCharacter", ResetCharacterItemMenu);

    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseClickCharacter", ResetCharacterItemMenu);
    }

    void ResetCharacterItemMenu(EventParameter eventParam)
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (ItemSlot item in eventParam.characterParam.inventory.Items)
        {
            GameObject gObject = Instantiate(textPrefab, parentTransform);
            gObject.GetComponent<ButtonNPCItemButton>().item = item;
        }
    }
}

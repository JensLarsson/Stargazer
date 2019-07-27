using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryMenu : MonoBehaviour
{

    public Transform targetParentTransform;
    public GameObject textPrefab;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Subscribe("ItemPurchased", ResetMenu);
        ResetMenu();
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("ItemPurchased", ResetMenu);
    }

    void ResetMenu(EventParameter eventParameter)
    {
        foreach (Transform child in targetParentTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemSlot slot in PlayerInfo.inventory._items)
        {
            GameObject gObject = Instantiate(textPrefab);
            gObject.transform.SetParent(targetParentTransform);
            gObject.GetComponent<ButtonPlayerItem>().item = slot;
        }
    }
    void ResetMenu()
    {
        foreach (Transform child in targetParentTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemSlot slot in PlayerInfo.inventory._items)
        {
            GameObject gObject = Instantiate(textPrefab);
            gObject.transform.SetParent(targetParentTransform);
            gObject.GetComponent<ButtonPlayerItem>().item = slot;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButtonAddItem : MonoBehaviour
{
    public Transform targetParent;
    public Text textPrefab;

    public void AddItem(string s)
    {
        Item item = new Item()
        {
            name = s
        };
        PlayerInfo.inventory.AddItem(item);

        foreach (Transform child in targetParent)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemSlot slot in PlayerInfo.inventory.items)
        {
            GameObject gObject = Instantiate(textPrefab.gameObject);
            gObject.transform.SetParent(targetParent);
            gObject.GetComponent<Text>().text = slot._item.name + " x" + slot._amount.ToString();
        }
    }
}

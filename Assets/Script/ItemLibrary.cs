using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[System.Serializable]
public class itemLibrary
{
    public List<Item> items = new List<Item>();

    public void CreateLibraryFile()
    {
        List<string> itemnames = new List<string>
        {
            "Robotics", "Resources", "Ship Parts", "Consumer Goods"
        };

        itemLibrary itemLib = new itemLibrary();
        foreach (string itName in itemnames)
        {
            Item item = new Item() { name = itName };
            itemLib.items.Add(item);
        }
        string outputString = JsonUtility.ToJson(itemLib);
        string location = Application.persistentDataPath + "/Data/ItemList.txt";
        File.WriteAllText(location, outputString);
    }
}

[System.Serializable]
public class ItemMaterial
{
    public enum Mat { Wooden, Bronze, Steel, Gold, Diamond, Katchin }
    Mat material;
    float[,] value;

    ItemMaterial()
    {
        value = new float[Enum.GetNames(typeof(Mat)).Length, 3];
    }
}
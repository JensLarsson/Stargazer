using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Planet
{
    public string name;
    [System.NonSerialized] public Texture texture;
    public int textureInt;
    public float planetScale;
    public Vector2 boardPosition;
    public List<Location> locations = new List<Location>();


    public string majorityPopString;
    public string minorityPopsString;

}

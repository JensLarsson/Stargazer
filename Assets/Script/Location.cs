using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Location
{
    public string name;
    Vector3 position;
    //[Tooltip("This is a normalized position in 3D space, which needs to be multiplied with the scale of a sphere")]
    public Vector3 Position
    {
        get
        {
            return position;
        }
        private set
        {
            position = value;
        }
    }
    public float planetOffset = 0;

    public Location()
    {
        GenerateLocation();
    }

    public void GenerateLocation()
    {
        position = Random.onUnitSphere;
    }
}

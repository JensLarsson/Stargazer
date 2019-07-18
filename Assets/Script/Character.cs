using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string name;
    public string[] currentLocation = new string[2];
    public Vector3 position;
    public float planetOffset;
    private float playerApproval;
    public float PlayerApproval
    {
        get
        {
            return playerApproval;
        }
        set
        {
            playerApproval = Mathf.Clamp(value, 0.0f, 100.0f);
        }
    }
    Inventory inventory = new Inventory();
}

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
    public Inventory inventory = new Inventory();
    public List<Quest> quests = new List<Quest>();
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

}

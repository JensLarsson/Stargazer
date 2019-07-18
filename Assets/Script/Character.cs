using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
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

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
    public List<int> quests = new List<int>();
    public List<CharacterDialogueBase> dialogues = new List<CharacterDialogueBase>();
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

    public List<CharacterDialogueBase> GetActiveDialogues()
    {
        List<CharacterDialogueBase> diags = new List<CharacterDialogueBase>();
        foreach (CharacterDialogueBase diag in dialogues)
        {
            if (!diag.deactivated)
            {
                diags.Add(diag);
            }
        }
        return diags;
    }

}

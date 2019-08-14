using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName = "Temp Name";
    public long questID;
    public string characterQuestIntroduction;
    public string questDescription;
    public List<QuestGoal> questGoals = new List<QuestGoal>();

    public List<ItemSlot> itemReward = new List<ItemSlot>();
    public int monetaryReward = 0;

    public bool QuestCompleted()
    {
        foreach (QuestGoal req in questGoals)
        {
            if (!req.Completed())
            {
                return false;
            }
        }
        return true;
    }

    public (List<ItemSlot>, int) ClaimReward()
    {
        return (itemReward, monetaryReward);
    }
}

[System.Serializable]
public abstract class QuestGoal
{
    public virtual bool Completed()
    {
        return true;
    }
    public virtual void generateRandomGoal()
    {

    }
}

[System.Serializable]
public class questItemReq : QuestGoal
{
    public List<ItemSlot> items = new List<ItemSlot>();

    public questItemReq(bool generateRandom = false)
    {
        if (generateRandom)
        {
            generateRandomGoal();
        }
    }
    public override bool Completed()
    {
        return PlayerInfo.inventory.HasItems(items);
    }
    public override void generateRandomGoal()
    {
        Inventory itemCreator = new Inventory();
        itemCreator.GenerateNewInventory(4);
        items = itemCreator._items;
    }
}

[System.Serializable]
public class questCreditReq : QuestGoal
{
    public int currencyCost;
    public override bool Completed()
    {
        return PlayerInfo.Currency >= currencyCost;
    }
    public override void generateRandomGoal()
    {

    }
}


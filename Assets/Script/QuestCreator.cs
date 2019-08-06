using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCreator
{
    Inventory itemCreator;
    public QuestCreator()
    {
        itemCreator = new Inventory();
    }
    public Quest GenerateRandomQuest()
    {
        Quest quest = new Quest();
        questItemReq itemReqs = new questItemReq(true);
        quest.questGoals.Add(itemReqs);

        quest.questDescription = QuestDescription(itemReqs);
        quest.characterQuestIntroduction = quest.questDescription; //This should be changed 

        return quest;
    }

    string QuestDescription(questItemReq quest)
    {
        string description = "Bring me <color=blue>";
        for (int i = 0; i < quest.items.Count; i++)
        {
            if (i > 0)
            {
                if (i == quest.items.Count - 1)
                {
                    description += "</color>, and <color=blue>";
                }
                else
                {
                    description += "</color>, <color=blue>";
                }
            }
            description += quest.items[i]._amount + "x " + quest.items[i].GetItemName();
        }
        description += "</color>, and I will reward you.";
        return description;
    }
}

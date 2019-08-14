using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class QuestManager
{
    public static List<Quest> quests;
    private static int nextQuestID
    {
        get
        {
            SavelatestQuestID();
            return nextQuestID;
        }
        set
        {
            nextQuestID = value;
        }
    }

    private static void LoadQuests(int id)
    {
        if (quests == null)
        {
            JSONserializer json = new JSONserializer();
            quests = json.loadQuests();
        }
    }

    private static void SavelatestQuestID()
    {
        GameData data = new GameData()
        {
            questID = nextQuestID
        };
        var outputString = JsonUtility.ToJson(data);
        Directory.CreateDirectory(Application.persistentDataPath + "/Data/");
        string location = Application.persistentDataPath + "/Data/GameData.txt";
        File.WriteAllText(location, outputString);
        Debug.Log(location);
    }

    public static Quest GenerateRandomQuest()
    {
        Quest quest = new Quest();
        questItemReq itemReqs = new questItemReq(true);
        quest.questGoals.Add(itemReqs);

        quest.questDescription = QuestDescription(itemReqs, quest);
        quest.characterQuestIntroduction = quest.questDescription; //This should be changed 
        quest.questID = nextQuestID;
        nextQuestID -= 1;   //Iterate to make sure that the same quest ID isn't reused

        JSONserializer json = new JSONserializer();
        json.SaveFile(quest);
        return quest;
    }

    static string QuestDescription(questItemReq questReq, Quest quest) //Test: generates character text based on quest requiements 
    {
        string description = "Bring me <color=blue>";
        for (int i = 0; i < questReq.items.Count; i++)
        {
            if (i > 0)
            {
                if (i == questReq.items.Count - 1)
                {
                    description += "</color>, and <color=blue>";
                }
                else
                {
                    description += "</color>, <color=blue>";
                }
            }
            description += questReq.items[i]._amount + "x " + questReq.items[i].GetItemName();
        }
        description += $"</color>, and I will reward you. \n <link=/Quest {quest.questID}>Accept</link>";
        return description;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public static class QuestManager
{
    public static List<Quest> quests;
    private static int nextQuestID = -1;
    private static int NextQuestID
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

    public static Quest GetQuest(int ID)
    {
        return quests.FirstOrDefault(z => z.questID == ID);
    }

    public static bool QuestExist(int ID)
    {
        Quest quest = new Quest()
        {
            questID = ID
        };
        return quests.Contains(quest);
    }

    public static void RefreshQuestList()
    {
        JSONserializer json = new JSONserializer();
        quests = json.loadQuests();
    }

    public static void LoadQuest(int id)
    {
        if (quests == null)
        {
            JSONserializer json = new JSONserializer();
            quests = json.loadQuests();
        }
        string location = Application.persistentDataPath + "/Data/GameData.txt";
        string s = File.ReadAllText(location);
        GameData data = JsonUtility.FromJson<GameData>(s);
        nextQuestID = data.questID;
        //foreach (Quest quest in quests)
        //{
        //    Debug.Log(quest.questID);
        //}
        Debug.Log(nextQuestID);
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
    }

    public static Quest GenerateRandomQuest()
    {

        Quest quest = new Quest();
        questItemReq itemReqs = new questItemReq(true);
        quest.questGoals.Add(itemReqs);

        quest.questID = nextQuestID;
        quest.questDescription = QuestDescription(itemReqs, quest);
        quest.characterQuestIntroduction = quest.questDescription; //This should be changed 
        //Debug.Log(quest.questID);
        NextQuestID -= 1;   //Iterate to make sure that the same quest ID isn't reused

        JSONserializer json = new JSONserializer();
        json.SaveFile(quest);
        return quest;
    }

    static string QuestDescription(questItemReq questReq, Quest quest) //Test: generates character text based on quest requiements 
    {
        Debug.Log(quest.questID);
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
        description += $"</color>, and I will reward you. \n <link=/GetQuest {quest.questID}>Accept</link>";
        return description;
    }
}

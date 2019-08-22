using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class TextCommandManager
{
    static TextCommandManager()
    {
    }


    public static bool ExecuteCommand(string command)
    {
        if (command[0] != '/')
        {
            Debug.Log("Not a Command");
            return false;
        }
        string[] commands = command.Split('&');
        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i][0] == ' ') //Removes first space to make formating after the '&' easier
            {
                commands[i] = commands[i].Remove(0, 1);
            }
            string[] commandParts = commands[i].Split(' ');

            switch (commandParts[0])
            {

                case "/Event":
                    EventParameter eventParam = new EventParameter
                    {
                        stringParam = commandParts[2]
                    };
                    EventManager.TriggerEvent(commandParts[1], eventParam);
                    break;

                case "/GetQuest":
                    int questInt;

                    questInt = int.Parse(commandParts[1]); //This should be TryParse, but shit's fucked, so I gave up for now
                    PlayerInfo.StartQuest(questInt);
                    //bool success;
                    //if (commandParts[1][0] == (char)45)
                    //{
                    //    string s = commandParts[1].Trim('-', ' ');

                    //    success = System.Int32.TryParse(s, out questInt);
                    //    questInt *= -1;
                    //}
                    //else
                    //{
                    //    success = int.TryParse(commandParts[1], out questInt);
                    //}
                    //if (success && QuestManager.QuestExist(questInt))
                    //{
                    //    Debug.Log(commandParts[1]);
                    //    PlayerInfo.quests.Add(questInt);
                    //}
                    //else
                    //{
                    //    Debug.LogError("input error: " + command + " " + questInt);
                    //}
                    break;

                case "/EndQuest":
                    int qInt;

                    qInt = int.Parse(commandParts[1]); //This should be TryParse, but shit's fucked, so I gave up for now
                    PlayerInfo.EndQuest(qInt);
                    break;

                case "/LoadScene":
                    int sceneID;
                    if (int.TryParse(commandParts[1], out sceneID))
                    {
                        SceneManager.LoadScene(sceneID);
                    }
                    else
                    {
                        SceneManager.LoadScene(commandParts[1]);
                    }
                    break;

                default:
                    return false;
            }
        }
        return true;
    }
}

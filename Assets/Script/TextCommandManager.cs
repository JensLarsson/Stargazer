using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextCommandManager
{
    static TextCommandManager()
    {
    }


    public static void ExecuteCommand(string command)
    {
        if (command[0] != 47)
        {
            Debug.Log("Not a Command");
            return;
        }
        string[] commandParts = command.Split(' ');

        switch (commandParts[0])
        {
            case "/Quest":
                int questInt;

                questInt = int.Parse(commandParts[1]); //This should be TryParse, but shit's fucked, so I gave up for now
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
        }
    }
}

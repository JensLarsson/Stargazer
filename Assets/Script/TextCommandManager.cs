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

                break;
        }
    }
}

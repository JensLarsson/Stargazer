using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogueBase
{
    public string text;
    public Quest quest;

    public void getQuest()
    {
        PlayerInfo.quests.Add(quest);
    }
}

public class Phrases
{
    public string[] greetings = new string[] { "Wazzup!", "Trunkicular", "What's crackin' Tinkerbilly?", "Dude,", "Totally radical, man!", "Hey, Homey!", "Tubular!", "Bitch'n", "What's Crackalackin'?" };

    public string GetRandomGreeting()
    {
        return greetings[Random.Range(0, greetings.Length)];
    }
}
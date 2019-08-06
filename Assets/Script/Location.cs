using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Location
{
    public string name;
    public string planetName;
    //[Tooltip("This is a normalized position in 3D space, which needs to be multiplied with the scale of a sphere")]
    public Vector3 position;

    public float planetOffset = 0;
    public List<Character> characters = new List<Character>();

    public void GenerateNewLocation()
    {
        name = Random.Range(0, 999999).ToString(); //This should be replaced with a name generator
        int characterCount = Random.Range(1, 6);
        Names names = new Names();
        QuestCreator questMaker = new QuestCreator();
        for (int i = 0; i < characterCount; i++)
        {
            (string surname, string familyname) = names.maleName();
            Character character = new Character()
            {
                name = surname + " " + familyname
            };
            character.inventory.GenerateNewInventory(10);
            character.quests.Add(questMaker.GenerateRandomQuest());
            characters.Add(character);
        }
    }
}

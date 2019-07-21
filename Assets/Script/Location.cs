using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Location
{
    public string name;
    public Vector3 position;
    //[Tooltip("This is a normalized position in 3D space, which needs to be multiplied with the scale of a sphere")]

    public float planetOffset = 0;
    public List<Character> characters = new List<Character>();




    public void GenerateNewLocation()
    {
        int characterCount = Random.Range(1, 6);
        Names names = new Names();
        for (int i = 0; i < characterCount; i++)
        {
            (string surname, string familyname) = names.maleName();
            Character character = new Character()
            {
                name = surname + " " + familyname
            };
            characters.Add(character);
        }
    }
}

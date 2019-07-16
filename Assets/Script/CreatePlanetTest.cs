using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlanetTest : MonoBehaviour
{
    public Text text;
    public void CreatePlanet()
    {
        Planet planet = new Planet()
        {
            name = Random.Range(0, 9999).ToString(),
            boardPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f))
        };
        JSONserializer json = new JSONserializer();
        text.text = json.SaveFile(planet);
        Color colour = text.color;
        colour.a = 3;
        text.color = colour;
    }

    public void DeletePlanets()
    {
        JSONserializer json = new JSONserializer();
        json.DeleteFolder(Application.persistentDataPath + "/Planets");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanetTest : MonoBehaviour
{
    public void CreatePlanet()
    {
        Planet planet = new Planet()
        {
            name = Random.Range(0, 9999).ToString(),
            boardPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f))
        };
        JSONserializer json = new JSONserializer();
        json.SaveFile(planet);
    }
}

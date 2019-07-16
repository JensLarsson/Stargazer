using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystem : MonoBehaviour
{
    public List<Planet> planets;

    private void Start()
    {
        JSONserializer json = new JSONserializer();
        planets = json.LoadAllPlanets();
        //if (PlayerInfo.currentPlanet == null && planets[0] != null)
        //{
        //    PlayerInfo.currentPlanet = planets[0];
        //}
    }
}

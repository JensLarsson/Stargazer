using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystem : MonoBehaviour
{
    float HorizontalMargin = 2.0f, topMargin = 1.0f, botMargin = 3.0f;
    public List<Planet> planets;
    public SpriteRenderer tempPlanetObject;
    List<GameObject> planetObjects = new List<GameObject>();

    public List<Texture2D> textures;

    private void Start()
    {
        setupSystem();

        EventManager.Subscribe("MouseDownPlanet", mouseOverPlanet);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseDownPlanet", mouseOverPlanet);
    }
    //Gör nånting baserat på vilken knapp som tryckts 
    void mouseOverPlanet(EventParameter eventParam)
    {
        Debug.Log(eventParam.planetParam.name);
    }


    public void setupSystem()
    {
        JSONserializer json = new JSONserializer();
        planets = json.LoadAllPlanets();
        if (PlayerInfo.currentPlanet == null && planets.Count > 0)
        {
            PlayerInfo.currentPlanet = planets[0];
        }
        foreach (GameObject gObject in planetObjects)
        {
            Destroy(gObject);
        }
        planetObjects = new List<GameObject>();
        foreach (Planet planet in planets)
        {
            planet.texture = textures[planet.textureInt];
            GameObject gObject = Instantiate(tempPlanetObject.gameObject);
            gObject.transform.position = planet.boardPosition;
            gObject.GetComponent<LocationIcon>().planet = planet;
            planetObjects.Add(gObject);
        }
    }

    public void CreatePlanet()
    {
        float vertical = Camera.main.orthographicSize;
        float horizontal = vertical * Screen.width / Screen.height;
        int i = Random.Range(0, textures.Count);
        Planet planet = new Planet()
        {
            name = Random.Range(0, 9999).ToString(),
            boardPosition = new Vector2(
            Random.Range(HorizontalMargin - horizontal, horizontal - HorizontalMargin),
            Random.Range(botMargin - vertical, vertical - topMargin)),
            textureInt = i,
            planetScale = Random.Range(4.0f, 10.0f)
        };
        JSONserializer json = new JSONserializer();
        Debug.Log(json.SaveFile(planet));
    }
}

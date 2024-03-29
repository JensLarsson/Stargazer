﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diorama : MonoBehaviour
{
    //Dioramat är klassen som representerar scenen där spelaren kan välja vilka platser/karaktären de vill ineragera med,
    //Här finns information om hur planeten/sektorn som besöks ser ut, och vilka beslut som finns tillgängliga
    public List<Item> items;
    List<Location> locations = new List<Location>();
    public MeshRenderer planetMesh;
    public Transform planetLight;
    public GameObject locationIcon;
    void Start()
    {
        JSONserializer json = new JSONserializer();
        locations = json.LoadLocations(PlayerInfo.currentPlanet.locations, PlayerInfo.currentPlanet.name);
        float planetScale = PlayerInfo.currentPlanet.planetScale; //Size of the planet
        planetMesh.transform.localScale = new Vector3(planetScale, planetScale, planetScale);
        planetMesh.material.SetTexture("_MainTex", PlayerInfo.currentPlanet.texture); //chnages the texture of the planet
        itemLibrary itL = new itemLibrary();
        itL.CreateLibraryFile();    //Temporary test, creates the JSON file of all the available items in the game

        foreach (Location location in locations)
        {
            GameObject gObject = Instantiate(locationIcon);
            Vector3 planetPos = planetMesh.transform.position;
            gObject.transform.position = planetPos + location.position * planetScale * 0.5f;
            gObject.transform.parent = planetMesh.transform;
            gObject.GetComponent<LocationIcon>().location = location;

            gObject.transform.rotation = Quaternion.LookRotation(-location.position);

        }
        float f = Random.Range(0.0f, 360.0f);
        planetMesh.transform.Rotate(Vector3.up, f);
        planetLight.transform.Rotate(Vector3.up, -f);
    }



}



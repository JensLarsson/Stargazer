using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLocationIcon : MonoBehaviour
{
    public Planet planet;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        EventManager.Subscribe("MouseDownPlanet", resetPlanetIcon);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseDownPlanet", resetPlanetIcon);
    }

    void resetPlanetIcon(EventParameter eventParam)
    {
        sr.color = Color.white;
    }

    private void OnMouseDown()
    {
        EventParameter eventParam = new EventParameter() { planetParam = planet };
        EventManager.TriggerEvent("MouseDownPlanet", eventParam);
        sr.color = Color.red;
    }
}

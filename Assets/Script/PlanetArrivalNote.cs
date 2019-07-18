using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetArrivalNote : MonoBehaviour
{
    [SerializeField] Text noteText;
    //public PlanetInfo planetInfo;
    private object temp;

    void Start()
    {
        noteText.text = string.Format(noteText.text, 
            PlayerInfo.currentPlanet.name, 
            PlayerInfo.currentPlanet.majorityPopString, 
            PlayerInfo.currentPlanet.minorityPopsString);
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorName : MonoBehaviour
{
    public Text textThing;

    void Start()
    {
        textThing.text = TempLibrary.randomSectorNames[Random.Range(0, TempLibrary.randomSectorNames.Count)];
    }

    void Update()
    {
        
    }
}

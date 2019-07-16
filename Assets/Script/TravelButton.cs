using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelButton : MonoBehaviour
{
    Planet targetPlanet = null;

    private void Start()
    {
        EventManager.Subscribe("MouseDownPlanet", SetTargetPlanet);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseDownPlanet", SetTargetPlanet);
    }

    void SetTargetPlanet(EventParameter eventParam)
    {
        targetPlanet = eventParam.planetParam;
    }

    public void TravelToPlanet()
    {
        if (targetPlanet != null)
        {
            PlayerInfo.currentPlanet = targetPlanet;
            SceneManager.LoadScene("JensTestDiorama");
        }
    }

}

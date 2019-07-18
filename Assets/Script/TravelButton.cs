using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelButton : MonoBehaviour
{
    public Planet targetPlanet;
    [SerializeField] string targetScene_PlanetScene;
    [SerializeField] public string targetScene_SectorScene;

    private void Start()
    {
        targetPlanet = null;
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
            SceneManager.LoadScene(targetScene_PlanetScene);
        }
    }

    public void TravelToSectorSystem()
    {
        SceneManager.LoadScene(targetScene_SectorScene);
    }

}

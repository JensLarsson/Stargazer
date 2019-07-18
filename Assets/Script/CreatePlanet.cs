using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanet
{
    public void CreateNew(List<Texture2D> textures, Vector2 potision)
    {
        float vertical = Camera.main.orthographicSize;
        float horizontal = vertical * Screen.width / Screen.height;
        int i = Random.Range(0, textures.Count);
        Planet planet = new Planet()
        {
            name = Random.Range(0, 9999).ToString(),
            boardPosition = potision,
            textureInt = i,
            planetScale = Random.Range(4.0f, 10.0f)
        };
        JSONserializer json = new JSONserializer();
        Debug.Log(json.SaveFile(planet));
    }
}

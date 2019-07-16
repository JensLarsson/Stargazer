using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{
    Text text;
    Color colour;
    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        colour = text.color;
        colour.a = 0;
        text.color = colour;
    }

    private void Update()
    {
        colour = text.color;
        colour.a -= Time.deltaTime;
        text.color = colour;
    }

}

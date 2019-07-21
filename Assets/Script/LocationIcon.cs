using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationIcon : MonoBehaviour
{
    [System.NonSerialized] public Location location;
    public Color colour;
    Color baseColour;
    [SerializeField] MeshRenderer iconMesh;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = iconMesh.material;
        EventManager.Subscribe("MouseDownLocation", ResetIcon);
        if (transform.localPosition.y < 0)
        {
            iconMesh.transform.Rotate(Vector3.forward, 90.0f);
            iconMesh.transform.localPosition = new Vector3(0, -0.5f);
        }
        baseColour = mat.color;
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseDownLocation", ResetIcon);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.identity;
    }


    void ResetIcon(EventParameter eventParam)
    {
        mat.color = baseColour;
    }

    private void OnMouseDown()
    {
        EventParameter eventParam = new EventParameter() { locationParam = location };
        EventManager.TriggerEvent("MouseDownLocation", eventParam);
        mat.color = colour;
    }
}

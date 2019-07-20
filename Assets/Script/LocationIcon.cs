using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationIcon : MonoBehaviour
{
    public Location location;
    [SerializeField] SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Subscribe("MouseDownLocation", ResetIcon);
        if (transform.localPosition.y < 0)
        {
            sr.transform.Rotate(Vector3.forward, 180.0f);
            sr.transform.localPosition = new Vector3(0, -0.5f);
        }
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe("MouseDownLocation", ResetIcon);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }


    void ResetIcon(EventParameter eventParam)
    {
        sr.color = Color.white;
    }

    private void OnMouseDown()
    {
        EventParameter eventParam = new EventParameter() { locationParam = location };
        EventManager.TriggerEvent("MouseDownLocation", eventParam);
        sr.color = Color.red;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsZoom : MonoBehaviour
{
    Camera cam;
    [SerializeField] float inZoom = 20f;
    [SerializeField] float notInZoom = 60f;
    bool zoom = false;
    void Start()
    {
        cam = GetComponentInParent<PlayerLook>().cam;
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(zoom == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    void ZoomIn()
    {
        zoom = true;
        cam.fieldOfView = inZoom;
        
    }

    void ZoomOut()
    {
        zoom = false;
        cam.fieldOfView = notInZoom;
    }
}

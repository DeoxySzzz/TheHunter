using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    [SerializeField] float xSensitive = 30f;
    [SerializeField] float ySensitive = 30f;

    public void ProcessLook(Vector2 vector2)
    {
        float xMouse = vector2.x;
        float yMouse = vector2.y;
        xRotation -= (yMouse * Time.deltaTime) * xSensitive;
        xRotation = Mathf.Clamp(xRotation, -65f, 65f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * Time.deltaTime * xMouse * ySensitive);
    }
}

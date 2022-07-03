using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    private CameraControl cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    public Vector3 movePlayer;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraControl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam.maxPos = newMaxPos;
            cam.minPos = newMinPos;
            other.transform.position += movePlayer;
        }
    }
}

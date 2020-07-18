using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothing;
    public float rotationSmoothing;
    public Transform player;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotationSmoothing);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }

    public void ResetCameraPosition()
    {
        player.rotation = Quaternion.Euler(0f, 0f, 0f); // player
        transform.rotation = Quaternion.Euler(0f, 0f, 0f); // main camera
    }

    public void ResetCameraPosition(Vector3 v)
    {
        player.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Euler(v.x, v.y, v.z);
    }
}

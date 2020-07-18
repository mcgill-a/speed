using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public bool disableMouselook = true;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    //public Transform target;
    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /*
         * Mouse look is currently disabled as I don't want the player to look around
         * 
        if (!disableMouselook)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        */

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCameraPosition()
    {
        playerBody.rotation = Quaternion.Euler(0f, 0f, 0f); // player
        transform.rotation = Quaternion.Euler(0f, 0f, 0f); // main camera
        xRotation = 0f;

    }

    public void ResetCameraPosition(Vector3 v)
    {
        playerBody.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Euler(v.x, v.y, v.z);
        xRotation = v.x;
    }
}

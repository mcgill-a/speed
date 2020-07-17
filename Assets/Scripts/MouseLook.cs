using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public bool disableMouselook = false;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    //public Transform target;
    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        if (!disableMouselook)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void ResetCameraPosition()
    {
        playerBody.rotation = Quaternion.Euler(0f, 0f, 0f); // player
        transform.rotation = Quaternion.Euler(0f, 0f, 0f); // main camera
        xRotation = 0;

    }

    public void ResetCameraPosition(float x, float y, float z)
    {
        playerBody.rotation = Quaternion.Euler(x, y, z);
        transform.rotation = Quaternion.Euler(x, y, z);
        xRotation = 0;
    }
}

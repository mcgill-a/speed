using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarController : MonoBehaviour
{
    public Rigidbody carModel = null;

    public float speed;
    public float turnSpeed;
    public float gravityMultiplier;
    public bool disableMovement = false;

    public TextMeshProUGUI speedometer;




    void Start()
    {
        carModel = GetComponent<Rigidbody>();
    }

    public void ResetMovements()
    {
        carModel.velocity = new Vector3(0f, 0f, 0f);
    }
    
    
    
    void FixedUpdate()
    {
        if (!disableMovement)
        {
            Move();
            Turn();
            Fall();
            UpdateSpeedometer();
        }
    }

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        carModel.AddRelativeForce(new Vector3(vertical, 0, vertical) * speed * 10);

        Vector3 localVelocity = transform.InverseTransformDirection(carModel.velocity);
        localVelocity.x = 0;
        carModel.velocity = transform.TransformDirection(localVelocity);
    }

    void Turn()
    {
        float horizontal = Input.GetAxis("Horizontal");
        carModel.AddTorque(new Vector3(0, horizontal, 0) * turnSpeed * 10);
    }

    void Fall()
    {
        carModel.AddForce(Vector3.down * gravityMultiplier * 10);
    }

    void UpdateSpeedometer()
    {
        Vector3 horizontalVelocity = carModel.velocity;
        horizontalVelocity = new Vector3(carModel.velocity.x, 0, carModel.velocity.z);

        // The speed on the x-z plane ignoring any speed
        float horizontalSpeed = horizontalVelocity.magnitude;
        // The speed from gravity or jumping
        float verticalSpeed = carModel.velocity.y;
        // The overall speed
        float overallSpeed = carModel.velocity.magnitude;
        int overallSpeedInt = (int)Mathf.Round(overallSpeed);
        speedometer.text = "Speed: " + overallSpeedInt.ToString();
    }
}

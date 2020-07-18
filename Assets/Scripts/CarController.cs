using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody carModel = null;

    public float speed;
    public float turnSpeed;
    public float gravityMultiplier;
    public bool disableMovement = false;

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
}

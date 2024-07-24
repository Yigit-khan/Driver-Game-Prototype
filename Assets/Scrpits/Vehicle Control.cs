using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
    //private Variables
    private float horizontalInput;
    private float forwardInput;


    private float turnSpeed = 25f;
    public float maxSpeed = 20f; 
    public float acceleration = 0.5f; 
    private float currentSpeed = 0f;

    public float downforce = 10f;
    public Vector3 centerOfMassOffset = new Vector3(0, -1, 0);
    public float drag = 1f;
    public float angularDrag = 2f;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMassOffset;
        rb.drag = drag;
        rb.angularDrag = angularDrag;
    }

    void LateUpdate()
    {
        // Player Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Acceleration
        if (forwardInput > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }
        else if (forwardInput < 0)
        {
            currentSpeed -= acceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, -maxSpeed);
        }
        else
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= acceleration * Time.deltaTime;
                if (currentSpeed < 0) currentSpeed = 0;
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += acceleration * Time.deltaTime;
                if (currentSpeed > 0) currentSpeed = 0;
            }
        }

        // Turn
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        // Movement
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

        // DownForce
        rb.AddForce(-transform.up * downforce * rb.velocity.magnitude);
    }
}

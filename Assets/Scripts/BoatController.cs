using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FloatObject))]
public class BoatController : MonoBehaviour
{
    public Vector3 COM;
    [Space(15)]
    public float speed = 1.0f;
    public float steerSpeed = 1.0f;
    public float movementThresold = 10.0f;

    public float uprightTorque = 1;

    Transform m_COM;

    float verticalInput;
    float movementFactor;
    float horizontalInput;
    float steerFactor;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    // Update is called once per frame
    void Update()
    {
        Balance();
        Movement();
        Steer();
    }

    void Balance()
    {
        var rot = Quaternion.FromToRotation(transform.up, Vector3.up);
        rb.AddTorque(new Vector3(rot.x, rot.y, rot.z) * uprightTorque);
    }

    void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThresold);
        rb.AddForce(transform.forward * movementFactor * speed);
    }

    void Steer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * verticalInput, Time.deltaTime / movementThresold);
        rb.AddTorque(0.0f, steerFactor * steerSpeed, 0.0f);
    }
}
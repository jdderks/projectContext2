using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float steerSpeed = 1f;
    [SerializeField]
    private float movementThreshold = 10f;

    private Vector3 COM; //Center of mass

    private Transform m_COM;

    private Rigidbody rb;

    private float verticalInput;
    private float horizontalInput;
    private float movementFactor;
    private float steerFactor;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        //Balance();
        Movement();
        Steer();
    }

    private void Balance()
    {
        if (!m_COM)
        {
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);
        }

        m_COM.position = COM;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }

    private void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
        transform.Translate(0.0f,0.0f,movementFactor);
    }
    private void Steer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * verticalInput, Time.deltaTime / movementThreshold);
        transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);

    }
}

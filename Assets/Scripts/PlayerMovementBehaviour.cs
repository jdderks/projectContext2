using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;    
    [SerializeField]
    private float rotationSpeed = 1f;
    [SerializeField]
    private float maxSpeed = 5f;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Horizontal");

        if (rb.velocity.x < maxSpeed && 
            rb.velocity.z < maxSpeed && 
            rb.velocity.x > -maxSpeed && 
            rb.velocity.z > -maxSpeed) {
            rb.AddForce(transform.forward * h * movementSpeed);
        }
        transform.Rotate(0,r * rotationSpeed,0, Space.Self);
    }
}

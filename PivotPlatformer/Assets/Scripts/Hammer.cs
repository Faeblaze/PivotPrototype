using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {
    public float force = 10F;
    public Rigidbody rb;

    private Vector3 offset;

    private void Awake()
    {
        offset = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = offset;
       // rb.AddForce(transform.up * force, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
            rb.AddForce(collision.contacts[0].normal * force, ForceMode.Impulse);
    }
}

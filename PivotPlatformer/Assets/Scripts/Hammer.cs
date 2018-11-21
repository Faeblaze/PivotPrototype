using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Player player;
    public float force = 10F;
    public float smallForce = 2F;

    public Rigidbody rb;

    private Vector3 offset;

    private bool grounded;

    private void Awake()
    {
        offset = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = offset;
        // rb.AddForce(transform.up * force, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        if (!grounded)
            rb.AddForce(-transform.right * smallForce, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            rb.AddForce(collision.contacts[0].normal * force, ForceMode.Impulse);
        else if (collision.collider.CompareTag("Death"))
            player.Die();
    }
        
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
            grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
            grounded = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5F;

    public Transform hammer;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        hammer.RotateAround(transform.position, new Vector3(1, 0, 0), vertical * speed * Time.deltaTime);
        hammer.RotateAround(transform.position, new Vector3(0, 0, -1), horizontal * speed * Time.deltaTime);

        //transform.localEulerAngles += (transform.right * vertical + transform.forward * horizontal) * speed * Time.deltaTime;

        //rb.MoveRotation(Quaternion.Euler(transform.eulerAngles + transform.right * horizontal));
    }
}

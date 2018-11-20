using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5F;

    public Transform hammer;

    public Camera pivotCamera;

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

        transform.rotation *= CameraRelativeRotation(0F, horizontal, vertical);

        //transform.rotation *= Quaternion.Euler(Vector3.down * vertical * speed * Time.deltaTime);
        //transform.rotation *= Quaternion.Euler(Vector3.back * horizontal * speed * Time.deltaTime);

        //hmmer.RotateAround(transform.position, Vector3.right, vertical * speed * Time.deltaTime);
        //hammer.RotateAround(transform.position, Vector3.back, horizontal * speed * Time.deltaTime);

        
    }

    // Borrowed from https://github.com/fuj1n/JMC_RollingJono/blob/master/RollingJono/Assets/Scripts/GameBoard.cs
    private Quaternion CameraRelativeRotation(float pitch, float yaw, float roll)
    {
        if (!pivotCamera)
            return Quaternion.Euler(new Vector3(roll, yaw, -pitch) * speed * Time.deltaTime);

        Vector3 relativePitch = pivotCamera.transform.TransformDirection(Vector3.down);
        Vector3 relativeYaw = pivotCamera.transform.TransformDirection(Vector3.back);
        Vector3 relativeRoll = pivotCamera.transform.TransformDirection(Vector3.right);

        Vector3 objectRelativePitch = transform.InverseTransformDirection(relativePitch);
        Vector3 objectRelaviveYaw = transform.InverseTransformDirection(relativeYaw);
        Vector3 objectRelaviveRoll = transform.InverseTransformDirection(relativeRoll);

        return Quaternion.AngleAxis(pitch * speed * Time.deltaTime, objectRelativePitch)
             * Quaternion.AngleAxis(yaw * speed * Time.deltaTime, objectRelaviveYaw)
             * Quaternion.AngleAxis(roll * speed * Time.deltaTime, objectRelaviveRoll);
    }
}

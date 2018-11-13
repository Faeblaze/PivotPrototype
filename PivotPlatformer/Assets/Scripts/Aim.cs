using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {
    public Transform axis;
    public float speed;

    private float cameraDistance;

    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - axis.position;
        cameraDistance = Vector3.Distance(axis.position, transform.position);
    }

    private void Update()
    {
        transform.position = axis.position + offset;

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.position = RotatePointAroundPivot(transform.position, axis.position, new Vector3(-y, x, 0) * speed * Time.deltaTime);
        transform.LookAt(axis);

        offset = transform.position - axis.position;
    }

    private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 direction = point - pivot;
        direction = Quaternion.Euler(angles) * direction;
        point = direction + pivot;

        return point;
    }



 //   function RotatePointAroundPivot(point: Vector3, pivot: Vector3, angles: Vector3): Vector3 {
 //  var dir: Vector3 = point - pivot; // get point direction relative to pivot
 //  dir = Quaternion.Euler(angles) * dir; // rotate it
 //   point = dir + pivot; // calculate rotated point
 //  return point; // return it
 //}

}

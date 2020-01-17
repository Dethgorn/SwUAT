using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public float rotationSpeed = 90f;

    private void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, axis);
    }
} 


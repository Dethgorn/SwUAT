using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraFollow : MonoBehaviour
{
    // the player to track
    public Transform player;
    // offset to keep the camera up
    public Vector3 offset;
    // rotation
    public float rotateSpeed;

    // private for camera
    private Camera theCamera;

    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        RotateToMousePosition();
    }

    void RotateToMousePosition()
    {
        // define the plane
        Plane groundPlane;
        groundPlane = new Plane(Vector3.up, player.position);
        // setup for raycasting
        float distance;
        Ray theRay;
        theRay = theCamera.ScreenPointToRay(Input.mousePosition);

        /* Written out raycasting
        theRay = new Ray();
        theRay.origin = theCamera.ScreenToWorldPoint(Input.mousePosition);
        theRay.direction = theCamera.transform.forward;
        */



        // raycast through the mouse
        if (groundPlane.Raycast(theRay, out distance))
        {
            // find world point where intersection is
            Vector3 intersectionPoint = theRay.GetPoint(distance);

            // math for rotate towards
            Quaternion targetRotation;
            Vector3 lookVector = intersectionPoint - player.position;
            targetRotation = Quaternion.LookRotation(lookVector, Vector3.up);

            // rotate towards the mouse
            player.rotation = Quaternion.RotateTowards(player.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectDown : MonoBehaviour
{
    public float moveSpeed; // Speed at which the object moves
    public float startY; // Initial y-position of the object
    public float targetY; // Target y-position of the object
    public bool isMoving = false; // Flag to check if object is moving
    public float moveUnits;

    void Awake()
    {
        moveSpeed *= 10;
        
        // Record the initial y-position of the object
        startY = transform.position.y;
        // Calculate the target y-position of the object
        targetY = startY - moveUnits; // Move down by 50 units
        
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            // Calculate how much to move the object this frame
            float step = moveSpeed * Time.deltaTime;
            // Move the object towards the target position
            transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, step), transform.position.z);

            // If the object has reached the target position, stop moving
            if (transform.position.y <= targetY)
            {
                // Set the position to exactly the target position
                transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
                isMoving = false;
            }
        }
    }

    // Method to start the movement
    public void StartMoving()
    {
        isMoving = true;
    }
}

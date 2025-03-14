using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float bobSpeed = 1f; // Speed at which the object bobs
    public float bobHeight = 1f; // Height of the bobbing motion
    private float startY; // Initial y-position of the object

    void Start()
    {
        // Record the initial y-position of the object
        startY = transform.position.y;
    }

    void Update()
    {
        // Calculate the new y-position based on sine wave motion
        float newY = startY + Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
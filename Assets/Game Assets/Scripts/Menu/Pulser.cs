using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulser : MonoBehaviour
{
    public GameObject objectToPulse; // Reference to the object to pulse
    public float pulseSpeed = 1f; // Speed of the pulse
    public float minScale = 0.5f; // Minimum scale of the object during the pulse
    public float maxScale = 1f; // Maximum scale of the object during the pulse

    private float currentScale; // Current scale of the object
    private bool increasingScale = true; // Whether the object's scale is currently increasing or decreasing

    void Start()
    {
        // Initialize the scale to the minimum scale
        currentScale = minScale;
    }

    void Update()
    {
        // Calculate the new scale based on the pulse speed
        float scaleChange = pulseSpeed * Time.deltaTime;

        // If the scale is increasing, increase it; otherwise, decrease it
        if (increasingScale)
        {
            currentScale += scaleChange;
            if (currentScale >= maxScale)
            {
                currentScale = maxScale;
                increasingScale = false;
            }
        }
        else
        {
            currentScale -= scaleChange;
            if (currentScale <= minScale)
            {
                currentScale = minScale;
                increasingScale = true;
            }
        }

        // Apply the new scale to the object
        objectToPulse.transform.localScale = Vector3.one * currentScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject positionOne; // Reference to the object to activate
    public GameObject positionTwo; // Reference to the object to flip
    public float delayTime = 1f; // Time to wait before flipping the object

    void Start()
    {
        positionOne.SetActive(true);
        positionTwo.SetActive(false);
        
        // Start the coroutine to activate objects
        StartCoroutine(ActivateAndFlipObjects());
    }

    IEnumerator ActivateAndFlipObjects()
    {
        while (true)
        {
            // Wait for delayTime seconds
            yield return new WaitForSeconds(delayTime);

            // Turn on the second object
            positionOne.SetActive(false);
            positionTwo.SetActive(true);

            // Wait for delayTime seconds
            yield return new WaitForSeconds(delayTime);
            
            // Turn on the second object
            positionOne.SetActive(true);
            positionTwo.SetActive(false);
        }
    }
}
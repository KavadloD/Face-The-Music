using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObject : MonoBehaviour
{
    private GameObject objectToShowHide;
    private bool isObjectActive = false;
    public float repeatRate;

    void Start()
    {
        objectToShowHide = gameObject; // You can assign the object through the inspector as well
        InvokeRepeating("ToggleVisibility", 0f, repeatRate); // Call ToggleVisibility every 2 seconds
    }

    void ToggleVisibility()
    {
        isObjectActive = !isObjectActive; // Toggle the state

        // Show or hide the object based on the current state
        if (isObjectActive)
        {
            objectToShowHide.SetActive(true);
        }
        else
        {
            objectToShowHide.SetActive(false);
        }
    }
}
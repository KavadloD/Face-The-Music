using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float cameraTimer;
    public float rotationSpeed;
    public bool isRotating;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTimer = 0;
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        cameraTimer += Time.deltaTime;

        if (isRotating)
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed));
        }
    }

    public void StartRotate()
    {
        isRotating = true;
    }
}

//at 30 seconds, rotate for 2 seconds lef, then right, then back to middle

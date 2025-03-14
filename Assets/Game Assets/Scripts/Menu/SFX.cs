using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Menu Button Select");
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Back");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Menu Button Press");
        }
    }
}

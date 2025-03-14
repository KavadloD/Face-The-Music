using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void PlayMusic()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
    
    public void StopMusic()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Stop();
    }

    public void VictorySFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Victory");
    }

    public void RankSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Rank");
    }
    
    public void ScoreSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Score Display");
    }
}


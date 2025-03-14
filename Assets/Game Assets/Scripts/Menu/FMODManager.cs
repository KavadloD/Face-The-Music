using UnityEngine;

public class FMODManager : MonoBehaviour
{
    void Start()
    {
        // Load all FMOD banks to avoid missing sounds
        FMODUnity.RuntimeManager.LoadBank("Master", true);
        FMODUnity.RuntimeManager.LoadBank("SFX", true);
        FMODUnity.RuntimeManager.LoadBank("Music", true);
    }
}

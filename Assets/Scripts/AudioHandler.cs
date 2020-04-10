using UnityEngine;

public class AudioHandler : MonoBehaviour
{

    public void SwitchAudio()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}

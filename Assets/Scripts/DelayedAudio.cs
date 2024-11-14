using UnityEngine;

public class DelayedAudio : MonoBehaviour
{
    public AudioSource audioSource;  // Assign the AudioSource in the Inspector
    public float delay = 3f;         // Set the delay time in seconds

    void Start()
    {
        Invoke("PlayAudio", delay);  // Call PlayAudio after the specified delay
    }

    void PlayAudio()
    {
        audioSource.Play();
    }
}

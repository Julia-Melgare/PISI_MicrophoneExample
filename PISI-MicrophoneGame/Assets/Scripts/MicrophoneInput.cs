using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{

    public float sensitivity = 100;
    public float loudness = 0;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.clip = Microphone.Start(null, true, 10, 44100);
        audioSource.loop = true; // Set the AudioClip to loop
        while (!(Microphone.GetPosition("") > 0))
        {
        } // Wait until the recording has started
        audioSource.Play(); // Play the audio source!
    }

    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audioSource.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
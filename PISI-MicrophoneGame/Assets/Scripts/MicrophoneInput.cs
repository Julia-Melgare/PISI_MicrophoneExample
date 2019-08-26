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
        //GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, 44100);
        audioSource.clip = Microphone.Start(null, true, 10, 44100);
        //GetComponent<AudioSource>().loop = true; // Set the AudioClip to loop
        audioSource.loop = true;
        //GetComponent<AudioSource>().mute = true; // Mute the sound, we don't want the player to hear it
        audioSource.mute = true;
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
        //GetComponent<AudioSource>().GetOutputData(data, 0);
        audioSource.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
            //Debug.Log("a " + a);
            //Debug.Log("/a " + a/256);
        }
        return a / 256;
    }
}
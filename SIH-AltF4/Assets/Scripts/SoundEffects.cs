using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip busStart;

    public void playSound(AudioClip src)
    {
        audioSource.clip = src;
        audioSource.Play();
    }
}

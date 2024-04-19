using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);

        }
        Instance = this;

    }
    public void ClickSound()
    {
        audioSource.PlayOneShot(audioClips[0]);

    }
    public void MisMatch()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }
    public void Match()
    {
        audioSource.PlayOneShot(audioClips[2]);
    }

    public void Win()
    {
        audioSource.PlayOneShot(audioClips[3]);
    }
}

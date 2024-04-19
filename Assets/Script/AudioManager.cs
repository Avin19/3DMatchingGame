using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);

        }
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
}

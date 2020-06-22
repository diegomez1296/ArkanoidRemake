using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private GameObject channels;
    private AudioSource[] audioSources;

    private void Start()
    {
        audioSources = channels.GetComponentsInChildren<AudioSource>();
    }

    public void PlayCollectSFX()
    {
        audioSources[0].Play();
    }

    public void PlayDefBlockSFX()
    {
        audioSources[1].Play();
    }

    public void PlayGlassBlockSFX()
    {
        audioSources[2].Play();
    }
}

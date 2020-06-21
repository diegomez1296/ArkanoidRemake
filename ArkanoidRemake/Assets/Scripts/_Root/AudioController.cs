using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource[] audioSources;

    private void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
    }
    public void PlaySFX(int channelIdx, AudioClip clip)
    {
        audioSources[channelIdx].clip = clip;
        audioSources[channelIdx].Play();
    }


    public void PlayCollectSFX()
    {
        PlaySFX(0, GameController.Instance.Data.audioClips[0]);
    }

    public void PlayDefBlockSFX()
    {
        PlaySFX(1, GameController.Instance.Data.audioClips[1]);
    }

    public void PlayGlassBlockSFX()
    {
        PlaySFX(2, GameController.Instance.Data.audioClips[2]);
    }
}

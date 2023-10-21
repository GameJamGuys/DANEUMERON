using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    [SerializeField]
    AudioClip music;

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = music;

        LevelManager.Instance.OnLevelEnd += MusicStop;
    }

    void MusicStop() => source.Stop();
}

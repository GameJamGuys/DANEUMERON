using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();

        LevelManager.Instance.OnLevelEnd += MusicStop;
    }

    void MusicStop() => source.volume = 0;
}

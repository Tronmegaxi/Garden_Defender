using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs_Controller.GetPlayerVolume();
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}

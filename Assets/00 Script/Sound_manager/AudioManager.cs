using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] _musicSound, _sfxSound;
    public AudioSource _musicSource, _sfxSource;
    #region Singleton
    private static AudioManager _instance = null;
    public static AudioManager Instance { get => _instance; }
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    private void Start()
    {
        SFXVolume(0.7f);
        MusisVolume(0.3f);
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(_musicSound, x => x.name == name);
        if (s == null) { Debug.Log("No Sound"); }
        else
        {
            _musicSource.clip = s.clip;
            _musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(_sfxSound, x => x.name == name);
        if (s == null) { Debug.Log("No Sound"); }
        else
        {
            _sfxSource.PlayOneShot(s.clip);
        }
    }
    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }
    public void ToggleSFX()
    {
        _sfxSource.mute = !_sfxSource.mute;
    }
    public void MusisVolume(float volume)
    {
        PlayerPrefs_Controller.SetPlayerVolume(volume);
        float _volume = PlayerPrefs_Controller.GetPlayerVolume();
        //_volume = volume;
        _musicSource.volume = _volume;
    }
    public void SFXVolume(float volume)
    {
        PlayerPrefs_Controller.SetPlayerSFX(volume);
        float _volume = PlayerPrefs_Controller.GetPlayerSFX();
        //_volume = volume;
        _sfxSource.volume = _volume;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    private void Start()
    {
        _musicSlider.value = PlayerPrefs_Controller.GetPlayerVolume();
        _sfxSlider.value = PlayerPrefs_Controller.GetPlayerSFX();

    }
    public void ToggleMusic()
    {
       AudioManager.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }
    public void Set_MusicVolume()
    {
         AudioManager.Instance.MusisVolume(_musicSlider.value);
    }
    public void Set_SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    public void ExitSoundSetting()
    {
        //PlayerPrefs_Controller.SetPlayerVolume(_musicSlider.value);
        //PlayerPrefs_Controller.SetPlayerSFX(_sfxSlider.value);

        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }



}

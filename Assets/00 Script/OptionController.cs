using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class OptionController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] int defaultDifficulty = 0;
    // [SerializeField] MusicPlayer _music;

    void Start()
    {
        volumeSlider.value = PlayerPrefs_Controller.GetPlayerVolume();
        difficultySlider.value = PlayerPrefs_Controller.GetDifficulty();

    }
    private void FixedUpdate()
    {
        SetMusic();
    }
    public void SaveandExit()
    {
        PlayerPrefs_Controller.SetPlayerVolume(volumeSlider.value);
        PlayerPrefs_Controller.SetDifficulty((int)difficultySlider.value);

        FindObjectOfType<Level_Load>().LoadMainMenu();
    }
    public void SetDefaultVolune()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
    public void SetMusic()
    {
        AudioManager.Instance.MusisVolume(volumeSlider.value);
    }
}

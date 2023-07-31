using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs_Controller : MonoBehaviour
{
    const string PLAYER_VOLUME_KEY = "player volume";
    const string PLAYER_SFX_KEY = "player SFXvolume";

    const string DIFFICULTY_KEY = "difficulty";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const int MIN_DIFFICULTY = 0;
    const int MAX_VDIFFICULTY = 2;


    public static void SetPlayerVolume(float volume)
    {
            //Debug.Log("Player volume set to: " + volume);
            PlayerPrefs.SetFloat(PLAYER_VOLUME_KEY, volume);
    }
    public static void SetPlayerSFX(float volume)
    {
            //Debug.Log("Player volume set to: " + volume);
            PlayerPrefs.SetFloat(PLAYER_SFX_KEY, volume);
    }
    public static float GetPlayerVolume()
    {
        return PlayerPrefs.GetFloat(PLAYER_VOLUME_KEY);
    }

    public static float GetPlayerSFX()
    {
       return PlayerPrefs.GetFloat(PLAYER_SFX_KEY);
    }
    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_VDIFFICULTY)
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("DIFFICULTY is out of range");
        }
    }
    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}

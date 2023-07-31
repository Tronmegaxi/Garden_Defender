using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLable;
    [SerializeField] GameObject louseLable;
    [SerializeField] GameObject pauseLable;
    [SerializeField] GameObject soundLable;
    [SerializeField] AttackerCheck _attackerParent;
    [SerializeField] float waitToLoad = 5f;

    bool levelTimerFinished = false;
    private void Start()
    {
        winLable.SetActive(false);
        louseLable.SetActive(false);
        pauseLable.SetActive(false);
        soundLable.SetActive(false);
    }
    
    private void FixedUpdate()
    {
        AttackerKilled();
    }
    public void AttackerKilled()
    {
        if (levelTimerFinished  )
        {
            if (_attackerParent.Attacker_Check())
            {
                StartCoroutine(HandleWinCondition());
                AudioManager.Instance.PlaySFX("MissionCompleted");
            }

        }
    }
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawn();
    }
    private void StopSpawn()
    {
        // tìm các gameobj có Attacker_Spawner gán vào array
        // Gọi hàm StopSpwaning trong các Attacker_Spawner để dừng spawn attacker
        Attacker_Spawner[] spawnArray = FindObjectsOfType<Attacker_Spawner>();
        foreach (Attacker_Spawner spawner in spawnArray)
        {
            spawner.StopSpwaning();
        }
    }
    IEnumerator HandleWinCondition()
    {
        yield return new WaitForSeconds(waitToLoad);
        winLable.SetActive(true);
        Time.timeScale = 0;
    }
    public void HandleLouseCondition()
    {
        louseLable.SetActive(true);
        Time.timeScale = 0;
    }
    public void HandlePause()
    {
        pauseLable.SetActive(true);
        Time.timeScale = 0;
    }
    public void CountinueGame()
    {
        pauseLable.SetActive(false);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        FindObjectOfType<Level_Load>().LoadNextScene();
        Time.timeScale = 1;
    }
    public void HandleSoundSetting()
    {
        soundLable.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitSoundSetting()
    {
        //PlayerPrefs_Controller.SetPlayerVolume(volumeSlider.value);
        soundLable.SetActive(false);
        Time.timeScale = 1;
    }
}

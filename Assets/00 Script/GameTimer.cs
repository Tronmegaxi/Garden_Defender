using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 5;
    [SerializeField] LevelController _levelController;
    bool triggeredLevelFinished = false;
    void Update()
    {
        EnterGame();
    }
    void EnterGame()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool isFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (isFinished)
        {
            _levelController.LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }

}

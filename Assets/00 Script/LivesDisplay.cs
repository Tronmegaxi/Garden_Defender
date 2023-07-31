using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int baseLives = 3;
    int _lives;
    int _damage = 1;

    Text livesText;

    void Start()
    {
        _lives=baseLives-PlayerPrefs_Controller.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
        //Debug.Log("difficulty is: "+PlayerPrefs_Controller.GetDifficulty());
    }
    void Update()
    {

    }
    private void UpdateDisplay()
    {
        livesText.text = _lives.ToString();
    }
    public void TakeLives()
    {
        _lives -= _damage;
        UpdateDisplay();
        if (_lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLouseCondition();
        }
    }
}

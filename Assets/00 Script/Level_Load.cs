using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Load : MonoBehaviour
{
    [SerializeField] float _waitTime = 3;
    int _currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_currentSceneIndex == 0)
        {
            StartCoroutine(WaitforTime());
        }
    }
    IEnumerator WaitforTime()
    {
        yield return new WaitForSeconds(_waitTime);
        LoadNextScene();
    }
    public void RestartScene()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(_currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }
    public void LoadLouseScreen()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadOptionScreen()
    {
        SceneManager.LoadScene("Option Screen");
    }
}

using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScriptGameOver : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        // hide the gameover screen at the beginning of the game
        panel.SetActive(false);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Brick-breaker");
        Time.timeScale = 1;
    }
    /// <summary>
    /// Method that shows the gameOver Menu
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    public void LoadGameOver(int score)
    {
        panel.SetActive(true);
        // stop the time so the ball stops moving
        Time.timeScale = 0;
    }
}

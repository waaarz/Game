using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; 

    void Start()
    {
       
        gameOverUI.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        Time.timeScale = 0f; 
        gameOverUI.SetActive(true); 
    }

    
    public void Retry()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    
    public void BackToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Main Menu"); 
    }
}
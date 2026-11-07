using UnityEngine;
using UnityEngine.SceneManagement;

public class Gametime : MonoBehaviour
{
    public float duration = 10f;

    private float timer;
    private bool isGameOver = false;

    void Start()
    {
        timer = duration;
    }

    void Update()
    {
        if (isGameOver) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isGameOver = true;


        SceneManager.LoadScene("Menu UFO");
    }
}
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void RemoveScore(int amount)
    {
        score -= amount;
        Debug.Log("Score: " + score);
    }
}
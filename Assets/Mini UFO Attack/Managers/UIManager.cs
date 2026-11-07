using UnityEngine;
using TMPro;

[DefaultExecutionOrder(-100)]

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text scoreText;
    public TMP_Text shieldText;
    public TMP_Text bombText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetScore(int s)
    {
        scoreText.text = $"Score: {s}";
    }

    public void SetShield(int v)
    {
        shieldText.text = $"Shield: {v}";
    }

    public void SetBombs(int v)
    {
        bombText.text = $"Bombs: {v}";
    }
}
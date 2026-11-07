using UnityEngine;
using TMPro;

public class Panier_script : MonoBehaviour
{
    private float moveSpeed = 10f;
    private int score = 0;
    public TextMeshPro displayed_text;
    private AudioSource monAudio;

    public AudioClip appleSound; 
    public AudioClip bombSound;  

    void Start()
    {
        displayed_text.SetText("Score : " + score);
        monAudio = GetComponent<AudioSource>();
        monAudio.playOnAwake = false;
    }

    void OnCollisionEnter2D(Collision2D col2)
    {
        if (col2.gameObject.CompareTag("Apple"))
        {
            score++;
            displayed_text.SetText("Score : " + score);
            monAudio.PlayOneShot(appleSound);
            Destroy(col2.gameObject); 
        }
        else if (col2.gameObject.CompareTag("Bomb"))
        {
            DecreaseScore();
            monAudio.PlayOneShot(bombSound);
            Destroy(col2.gameObject); 
        }
    }

    public void DecreaseScore()
    {
        score--;
        displayed_text.SetText("Score : " + score);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
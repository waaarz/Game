using UnityEngine;

public class BounceSounds : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la balle touche une brique
        if (collision.gameObject.CompareTag("Brick"))
        {
            audioSource.Play();
        }

        // Si elle touche le pad
        if (collision.gameObject.CompareTag("Pad"))
        {
            audioSource.Play();
        }

        // Si elle touche un mur
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.Play();
        }
    }
}
using UnityEngine;

public class Catchboy : MonoBehaviour
{
    public int score = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            score += 1;
            Destroy(other.gameObject);
           
        }
        else if (other.CompareTag("Bomb"))
        {
            score -= 2; 
            Destroy(other.gameObject);
            
        }
    }
}
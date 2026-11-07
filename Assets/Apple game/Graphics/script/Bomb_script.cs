using UnityEngine;

public class BombScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Panier"))
        {
            
            

            Panier_script panier = other.GetComponent<Panier_script>();
            if (panier != null)
            {
                panier.DecreaseScore();
            }

            Destroy(gameObject);
        }
    }
}
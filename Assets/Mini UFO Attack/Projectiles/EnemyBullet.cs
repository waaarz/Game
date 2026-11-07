using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -12f) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log($"{name} hit {col.name} on {Time.time}");

        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().Damage(1);
            Destroy(gameObject);
        }
    }
}
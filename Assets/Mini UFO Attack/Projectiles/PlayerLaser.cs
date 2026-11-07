using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public float speed = 15f;
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        if (transform.position.x > 12f) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out EnemyBase e))
        {
            e.Damage(1);
            Destroy(gameObject);
        }
    }
}
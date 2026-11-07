using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius = 15f;
    public LayerMask enemyLayer;

    void Start()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        foreach (var h in hits)
        {
            EnemyBase e = h.GetComponent<EnemyBase>();
            if (e != null) e.Kill();
        }
        Destroy(gameObject, 0.5f);
    }
}
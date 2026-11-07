using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public int life = 1;
    public int scoreValue = 100;
    public GameObject deathFx;
    public GameObject powerupPrefab;

    protected virtual void Update()
    {
        Move();
        Attack();
    }

    public virtual void Move() { }
    public virtual void Attack() { }

    public virtual void Damage(int d = 1)
    {
        life -= d;
        if (life <= 0) Kill();
    }

    public virtual void Kill()
    {
        if (deathFx) Instantiate(deathFx, transform.position, Quaternion.identity);
        GameManager.Instance.AddScore(scoreValue);
        TryDrop();
        Destroy(gameObject);
    }

    void TryDrop()
    {
        if (Random.value < 0.1f && powerupPrefab)
            Instantiate(powerupPrefab, transform.position, Quaternion.identity);
    }
}
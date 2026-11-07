using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [Header("Move")]
    public float speed = 6f;
    public Vector2 limitMin = new Vector2(-8, -4);
    public Vector2 limitMax = new Vector2(8, 4);

    [Header("Fire")]
    public GameObject laserPrefab;
    public Transform shootOrigin;
    public float fireRate = .15f;
    private float nextFire;

    [Header("Shield & Bomb")]
    public int maxShield = 5;
    public int bombs = 3;
    public GameObject bombPrefab;
    public float invTime = 1.5f;

    private int shield;
    private bool invincible;
    private SpriteRenderer sprite;

    void Awake()
    {
        shield = maxShield;
        UIManager.Instance.SetShield(shield);
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ---- Movement ----
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += dir.normalized * speed * Time.deltaTime;

        // Clamp to screen limits
        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, limitMin.x, limitMax.x);
        p.y = Mathf.Clamp(p.y, limitMin.y, limitMax.y);
        transform.position = p;

        // ---- Fire ----
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(laserPrefab, shootOrigin.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

        // ---- Super bomb ----
        if (Input.GetKeyDown(KeyCode.B) && bombs > 0)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            bombs--;
            UIManager.Instance.SetBombs(bombs);
        }

        // ---- Escape to Menu ----
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Damage(int d = 1)
    {
        Debug.Log("Damage called");
        if (invincible) return;
        shield -= d;
        UIManager.Instance.SetShield(shield);
        if (shield <= 0) Die();
        else StartCoroutine(IFrames());
    }

    public void AddShield(int amount)
    {
        shield = Mathf.Clamp(shield + amount, 0, maxShield);
        UIManager.Instance.SetShield(shield);
    }

    public void AddBomb(int amount)
    {
        bombs += amount;
        UIManager.Instance.SetBombs(bombs);
    }

    void Die()
    {
        GameManager.Instance.GameOver();
        gameObject.SetActive(false);
    }

    System.Collections.IEnumerator IFrames()
    {
        invincible = true;
        float t = 0;
        while (t < invTime)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.12f);
            t += .12f;
        }
        sprite.enabled = true;
        invincible = false;
    }
}
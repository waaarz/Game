using UnityEngine;

public class Spawner_script : MonoBehaviour
{
    public AudioClip clip;
    public GameObject Apple_prefab;
    public GameObject Bomb_prefab; 

    protected float timer = 1.5f;
    private float x;

    private AudioSource monAudio;

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            AppleOrBombSpawn(); 
            timer = 1.5f;
        }
    }

    void AppleOrBombSpawn()
    {
        x = Random.Range(-8.5f, 8.5f);
        
       
        GameObject prefabToSpawn = (Random.value < 0.8f) ? Apple_prefab : Bomb_prefab;

        Instantiate(prefabToSpawn, new Vector3(x, 0.9f, 0), Quaternion.identity);
    }
}
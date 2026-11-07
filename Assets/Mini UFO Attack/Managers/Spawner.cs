using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [System.Serializable] public struct Wave
    {
        public GameObject prefab;
        public int count;
        public float spawnRate;
    }
    public Wave[] waves;

    IEnumerator Start()
    {
        foreach (var w in waves)
        {
            for (int i = 0; i < w.count; i++)
            {
                Vector3 pos = new Vector3(10, Random.Range(-4f, 4f), 0);
                Instantiate(w.prefab, pos, Quaternion.identity);
                yield return new WaitForSeconds(1f / w.spawnRate);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
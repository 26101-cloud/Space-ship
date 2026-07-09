using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] float interval = 2f;
    [SerializeField] float spawnY = 7f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, interval);
    }

    // Update is called once per frame
    void Spawn()
    {
        float x = Random.Range(-2.5f, 2.5f);
        int enemys = Random.Range(0, enemyPrefab.Count);
        Vector3 pos = new Vector3(x, spawnY, 0f);
        Instantiate(enemyPrefab[enemys], pos, Quaternion.identity);
    }
}

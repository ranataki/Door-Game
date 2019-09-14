using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject guy;
    public GameObject spawnedGuy;
    public GameObject enemy;
    public GameObject spawnedEnemy;

    public Transform target;

    public ScoreManager scoreManager;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAll", 1f, 1.5f);
    }

    void FixedUpdate()
    {
        if (scoreManager.gameOver)
        {
            CancelInvoke("SpawnAll");
        }
    }

    void SpawnAll()
    {
        int rand = Random.Range(0, 10);

        if (rand < 3)
        {
            SpawnEnemy();
        }
        else if (rand >= 3)
        {
            SpawnGuy();
        }
    }

    void SpawnEnemy()
    {
        pos = new Vector3(Random.Range(-5f, -3.5f), -0.17f, Random.Range(-2f, 2.4f));
        spawnedEnemy = Instantiate(enemy, pos, enemy.transform.rotation);
    }

    void SpawnGuy()
    {
        pos = new Vector3(Random.Range(-5f, -3.5f), -0.17f, Random.Range(-2f, 2.4f));
        spawnedGuy = Instantiate(guy, pos, enemy.transform.rotation);
    }
}

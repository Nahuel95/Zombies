using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    float timePlayed = 0;
    float timer = 3f;
    int spawnedEnemies = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime;
        if (timer <= 0)
        {
            spawnedEnemies = Mathf.CeilToInt(Mathf.Sqrt(timePlayed));
            for (int i = 0; i < spawnedEnemies; i++)
            {
                float x = Random.Range(-100, 100);
                float y = Random.Range(-100, 100);
                float dist = Random.Range(20, 50);
                Vector3 pos = new Vector3(x, y, 0).normalized*dist;
                Enemy newEnemy = Instantiate(enemy, transform.position + pos, Quaternion.identity);
                newEnemy.Health = newEnemy.Health + timePlayed / 15;
            }
            timer = 3f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}

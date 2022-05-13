using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IAbility
{ 
    public int Level { get; set; }
    public float InvocationRate { get; set; } = 5f;
    public float Size { get; set; } = 2f;
    public float Duration { get; set; } = 5f;
    float invocationCount;
    public GameObject wall;

    // Start is called before the first frame update
    public void Start()
    {
        invocationCount = InvocationRate;
    }

    // Update is called once per frame
    public void Update()
    {
        if (invocationCount <= 0)
        {
            GameObject newWall = Instantiate(wall, transform.position, Quaternion.identity);
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            Enemy enemy = null;
            if (enemies.Length > 0)
            {
                enemy = enemies[0];
            }
            if (enemy != null)
            {
                foreach (Enemy e in enemies)
                {
                    if ((e.transform.position - transform.position).magnitude < (enemy.transform.position - transform.position).magnitude)
                    {
                        enemy = e;
                    }
                }
                newWall.transform.up = enemy.transform.position - newWall.transform.position;
                newWall.GetComponent<Wall>().Duration = Duration;
            }
            invocationCount = InvocationRate;
        }
        else {
            invocationCount -= Time.deltaTime;
        }
    }
}

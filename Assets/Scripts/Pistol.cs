using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    public float Range { get; set; } = 8f;
    public float Damage { get; set; } = 3f;
    public Sprite Sprite { get; set; }
    public float ROF { get; set; } = 0.5f;
    float fireCount;
    public NormalBullet bullet;

    // Start is called before the first frame update
    public void Start()
    {
        fireCount = ROF;
    }

    // Update is called once per frame
    public void Update()
    {
        if (fireCount <= 0) {
            Activate();
        }
        else
        {
            fireCount -= Time.deltaTime;
        }
    }
    public void Activate()
    {
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            Enemy enemy = null;
            if (enemies.Length > 0) {
                enemy = enemies[0];
            }
            if (enemy != null) {
                foreach (Enemy e in enemies)
                {
                    if ((e.transform.position - transform.position).magnitude < (enemy.transform.position - transform.position).magnitude)
                    {
                        enemy = e;
                    }
                }
                if ((enemy.transform.position - transform.position).magnitude <= Range)
                {
                    Shoot(enemy);
                    fireCount = ROF;
                }
            }  
        }
    }

    void Shoot(Enemy enemy) {
        NormalBullet newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.Target = enemy;
        newBullet.Damage = Damage;
    }
}

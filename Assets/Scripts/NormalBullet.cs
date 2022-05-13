using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public Enemy Target { get; set; }
    float Movespeed { get; set; } = 5f;
    Rigidbody body;
    Collider coll;
    public float Damage { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.velocity = (Target.transform.position - transform.position) * Movespeed;
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.Health -= Damage;
        }
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerController player;
    float movespeed = 1f;
    Rigidbody body;
    Collider coll;
    public float Health { get; set; } = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        body = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity =  (player.transform.position - transform.position).normalized * movespeed;
        if (Health <= 0) {
            Die();
        }
    }

    void Die() {
        Destroy(this.gameObject);
    }
}

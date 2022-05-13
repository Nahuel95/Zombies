using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite : MonoBehaviour, IAbility
{
    public int Level { get; set; } = 1;
    public int Amount { get; set; } = 3;
    public float RotationSpeed { get; set; } = 50f;
    public float OrbDamage { get; set; }  = 10f;
    PlayerController player;
    public GameObject Orb;
    GameObject[] satelites;
    float distance = 1.5f;
    // Start is called before the first frame update
    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
        satelites = new GameObject[Amount];
        createSatelites();
    }

    // Update is called once per frame
    public void Update()
    {
        this.transform.Rotate(transform.forward * RotationSpeed * Time.deltaTime);
    }
    void createSatelites(){
        float angle = (2 * Mathf.PI) / Amount;
        for (int i = 0; i < Amount; i++) {
            float t = angle * i;
            float x = distance * Mathf.Cos(t);
            float y = distance * Mathf.Sin(t);
            Vector3 pos = transform.position + new Vector3(x, y, 0);
            satelites[i] = Instantiate(Orb, pos, Quaternion.identity, transform);
            satelites[i].GetComponent<Orb>().Damage = OrbDamage;
        }
    }
}

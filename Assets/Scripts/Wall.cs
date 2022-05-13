using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float Duration { get; set; } = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Duration <= 0)
        {
            Destroy(this.gameObject);
        }
        else {
            Duration -= Time.deltaTime;
        }
    }
}

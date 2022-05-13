using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    float Range { get; set; }
    float Damage { get; set; }
    Sprite Sprite { get; set; }
    float ROF { get; set; }
    // Start is called before the first frame update
    void Start();

    // Update is called once per frame
    void Update();

    void Activate();
}

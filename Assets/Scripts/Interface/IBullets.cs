using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullets
{
    int BulletDamage { get; }
    float BulletSpeed { get; set; }
}

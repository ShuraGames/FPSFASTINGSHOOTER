using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentHit : MonoBehaviour, Hit
{
    public GameObject envirHit;

    public void Accept(IVisitor visiter, Vector3 pos)
    {
        visiter.Visit(this, pos, envirHit);
    }
}

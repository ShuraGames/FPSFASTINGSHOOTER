using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentHit : Hit
{
    public GameObject envirHit;

    public override void Accept(IVisitor visiter, Vector3 pos)
    {
        visiter.Visit(this, pos, envirHit);
    }
}

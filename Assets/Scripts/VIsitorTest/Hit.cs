using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Hit
{
    void Accept(IVisitor visiter, Vector3 pos);
}

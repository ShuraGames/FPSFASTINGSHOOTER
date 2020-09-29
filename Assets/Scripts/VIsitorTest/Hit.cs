using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hit: MonoBehaviour
{
    public abstract void Accept(IVisitor visiter, Vector3 pos);
}

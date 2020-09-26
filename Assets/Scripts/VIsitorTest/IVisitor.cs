using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitor
{
    void Visit(TargetHit hit, Vector3 pos, GameObject inst);
    void Visit(EnviromentHit hit, Vector3 pos, GameObject inst);
}

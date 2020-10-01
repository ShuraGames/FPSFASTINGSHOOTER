using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HitEffectSpawner : MonoBehaviour, IVisitor
{
    [Header("List HitEffects")]
    [SerializeField] private GameObject _effectGunHit;
    [SerializeField] private GameObject _effectRifleHit;

    public void Visit(TargetHit hit, Vector3 pos, GameObject inst)
    {
        SpawnObject(pos, inst);
    }

    public void Visit(EnviromentHit hit, Vector3 pos, GameObject inst)
    {
        SpawnObject(pos, inst);
    }

    private void SpawnObject(Vector3 pos, GameObject inst)
    {
        var instObj = Instantiate(inst, pos, Quaternion.LookRotation(pos.normalized));
        Destroy(instObj, 2f);
    }
}   
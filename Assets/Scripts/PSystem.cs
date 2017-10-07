using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[ExecuteInEditMode]
public class PSystem : MonoBehaviour {

    public float scale;
    public float speed;
    public Vector3 rotate;
    
	void Start () {
        refresh();
    }

    void refresh()
    {
        ParticleSystem pSys = GetComponent<ParticleSystem>();
        var pMain = pSys.main;
        pMain.startSize = scale;
        var pVelo = pSys.velocityOverLifetime;
        pVelo.xMultiplier = speed;
        pVelo.yMultiplier = speed;
        pVelo.zMultiplier = speed;
    }

    private void OnValidate()
    {
        refresh();
    }
}

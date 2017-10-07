using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    GameObject owner;
    public float speed;
    public float life = 12;
    float death;
    bool fired;
	
	// Update is called once per frame
	void Update () {
        Vector3 p = transform.position;
        p += transform.forward * speed * Time.deltaTime;
        transform.position = p;

        if (fired && Time.time > death)
            Destroy(gameObject);
	}

    public void fire(GameObject shooter)
    {
        owner = shooter;
        death = Time.time + life;
        fired = true;
    }
}

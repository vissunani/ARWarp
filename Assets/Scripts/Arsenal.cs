using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arsenal : MonoBehaviour {

    public static Arsenal main;
    public Bullet[] ammo;

	// Use this for initialization
	void Awake () {
        main = this;
    }

    public static Bullet fire(GameObject owner, int bulletIndex)
    {
        return fire(owner, bulletIndex, owner.transform.position, owner.transform.forward);
    }

    public static Bullet fire(GameObject owner, int bulletIndex, Vector3 position, Vector3 forward)
    {
        int i = Mathf.Clamp(bulletIndex, 0, main.ammo.Length - 1);
        Bullet b = Instantiate(main.ammo[i]) as Bullet;
        b.transform.position = position;
        b.transform.forward = forward;
        b.fire(owner);

        return b;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quasar : MonoBehaviour {

    public float period = 8;
    private float time;
    private float pScale;

	// Use this for initialization
	void Start () {
        time = period;
        pScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        float s = pScale;
        float t = time - Time.time;

        if (t > (period - 1))
            s = Mathf.Lerp(0, pScale, period - t);
        else if (t < 1)
            s = Mathf.Lerp(pScale, 0, t);

		if(Time.time > time)
        {
            Vector2 circ = Random.insideUnitCircle;
            Vector3 aim = Vector3.forward * 8;
            aim.x = ( circ.x + 1 ) / 2;
            aim.y = ( circ.y + 1 ) / 2;

            transform.position = GoogleARCore.ARCoretroller.mainCamera.ViewportToWorldPoint(aim);

            time = Time.time + period;
        }
	}
}

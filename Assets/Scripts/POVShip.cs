using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVShip : MonoBehaviour {

    public static POVShip main;

    [Header("Camera")]
    Camera mainCamera;
    public Vector3 cameraOffset;
    [Header("Ship")]
    public float speed;

    // Use this for initialization
    private void Awake()
    {
        main = this;
    }

    void Start () {
        mainCamera = GoogleARCore.ARCoretroller.mainCamera;
	}

    private void LateUpdate()
    {
        Vector3 f = mainCamera.transform.forward;
        f.y = 0;
        if (f.sqrMagnitude > 0.2f)
            transform.forward = Vector3.Slerp(transform.forward, f, Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {
        Vector3 goal = mainCamera.transform.position
            +   Vector3.up * cameraOffset.y
            +   mainCamera.transform.right * cameraOffset.x
            +   mainCamera.transform.forward * cameraOffset.z;
        Vector3 start = transform.position;
        /*if (Vector3.Distance(start, goal) < speed)
            start = Vector3.Lerp(start, goal, 0.5f);*/
        transform.position = Vector3.Lerp(start, goal, Time.deltaTime);
        /*Vector3 travel = goal - transform.position;

        if (travel.sqrMagnitude > 1)
            travel.Normalize();

        float s = Mathf.Pow( travel.magnitude + 1 , 2 ) * speed;

        transform.position = transform.position + travel * s * Time.deltaTime;*/
	}

    public static Vector3 location()
    {
        return main.transform.position;
    }
    public static Vector3 direction()
    {
        return main.transform.forward;
    }
}

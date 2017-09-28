using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject ObjectToFollow;
    private Rigidbody rb;
    private Transform tr;

    public float cameraDistance;

    private Vector3 offset;

    private GameObject target;
    private Transform trTarget;

    public float x, y, z;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        trTarget = target.GetComponent<Transform>();
        setOffset();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        x = trTarget.position.x + offset.x;
        y = trTarget.position.y + offset.y;
        z = trTarget.position.z + offset.z;
        rb.MovePosition(trTarget.position + offset);
	}

    void setOffset()
    {
        float x, y, z;

        y = 2.25f;

        x = Mathf.Sqrt(Mathf.Pow(cameraDistance, 2.0f) + Mathf.Pow(y, 2.0f));

        offset = new Vector3(x, y, 0.0f);
    }
}

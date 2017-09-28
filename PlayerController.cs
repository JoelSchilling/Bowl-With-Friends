using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool position = false;
    private bool thrown = false;

    public float targetSpeed;
    public float angle;
    public float loft;
    public float hook;
    public float current;

    private Rigidbody rb;
    private Transform tr;

    private Vector3 maxRange;
    private Vector3 minRange;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    void Throw()
    {
        float speed;

        speed = Mathf.Sqrt((Mathf.Pow(targetSpeed, 2.0f) - Mathf.Pow(loft, 2.0f) - Mathf.Pow(angle, 2.0f)));
        rb.velocity = new Vector3(speed, loft, -angle);
        rb.maxAngularVelocity = Mathf.Infinity;
        rb.AddTorque(transform.right * hook);
        thrown = true;
    }

    void FixedUpdate()
    {
        bool click = Input.GetMouseButtonDown(0);
        float right = Input.GetAxis("Horizontal");
        /*float moveHorizontal = -Input.GetAxis("Horizontal");
        float moveVertical = -Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        */

        //float v = Input.GetAxis("vertical");

        if (!position)
        {
            rb.freezeRotation.Equals(true);
            float deltaPosition = -Input.GetAxis("Horizontal");
            Vector3 move = new Vector3(0.0f, 0.0f, deltaPosition * .02f);
            Vector3 position = tr.position;
            if (position.z + move.z + rb.velocity.z < 0.5 & position.z + move.z + rb.velocity.z > -0.5)
            {
                rb.MovePosition(position + move);
                //rb.velocity.Set(0.0f, 0.0f, 0.0f);
                
            }
            else
            {
                if(tr.position.z < -0.5f)
                {
                    maxRange = new Vector3(tr.position.x, tr.position.y, -0.5f);
                    rb.MovePosition(maxRange);
                }
                if(tr.position.z > 0.5f)
                {
                    minRange = new Vector3(tr.position.x, tr.position.y, 0.5f);
                    rb.MovePosition(minRange);
                }
            }
        }
        if (click & !thrown)
        {
            rb.freezeRotation.Equals(false);
            Throw();
            position = true;
        }
        current = rb.velocity.magnitude;
    }

}

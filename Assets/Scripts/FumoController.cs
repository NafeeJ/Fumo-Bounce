using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumoController : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D fumoRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        fumoRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            fumoRigidbody.AddForce(new Vector2(movementSpeed, 0f), ForceMode2D.Force);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            fumoRigidbody.AddForce(new Vector2(-movementSpeed, 0f), ForceMode2D.Force);
        }

        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            fumoRigidbody.AddForce(new Vector2(0f, movementSpeed * 1.4f), ForceMode2D.Force);
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            fumoRigidbody.AddForce(new Vector2(0f, -movementSpeed), ForceMode2D.Force);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumoController : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D fumoRigidbody;
    private SpriteRenderer fumoSprite;

    // Start is called before the first frame update
    void Start()
    {
        fumoRigidbody = GetComponent<Rigidbody2D>();
        fumoSprite = GetComponent<SpriteRenderer>();
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
            fumoRigidbody.AddForce(new Vector2(0f, movementSpeed * 1.2f), ForceMode2D.Force);
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            fumoRigidbody.AddForce(new Vector2(0f, -movementSpeed * 0.8f), ForceMode2D.Force);
        }
    }

    public IEnumerator DisappearFumoCoroutine()
    {
        while (fumoSprite.color.a > 0)
        {
            fumoSprite.color = new Color(255, 255, 255, fumoSprite.color.a - Time.deltaTime);
            yield return null;
        }

        Destroy(this.gameObject); // :(
    }
}

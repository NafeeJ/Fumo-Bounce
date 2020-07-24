using System.Collections;
using UnityEngine;

public class FumoController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    private Rigidbody2D fumoRigidbody;
    private SpriteRenderer fumoSprite;

    void Start()
    {
        fumoRigidbody = GetComponent<Rigidbody2D>();
        fumoSprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            fumoRigidbody.AddForce(new Vector2(movementSpeed, 0f));
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            fumoRigidbody.AddForce(new Vector2(-movementSpeed, 0f));
        }

        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            fumoRigidbody.AddForce(new Vector2(0f, movementSpeed * 1.2f));
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            fumoRigidbody.AddForce(new Vector2(0f, -movementSpeed * 0.8f));
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

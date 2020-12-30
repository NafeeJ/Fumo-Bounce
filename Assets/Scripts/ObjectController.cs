using System.Collections;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody2D objRigidbody;
    private SpriteRenderer objSprite;

    void Awake()
    {
        objRigidbody = GetComponent<Rigidbody2D>();
        objSprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            objRigidbody.AddForce(new Vector2(movementSpeed, 0f));
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            objRigidbody.AddForce(new Vector2(-movementSpeed, 0f));
        }

        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            objRigidbody.AddForce(new Vector2(0f, movementSpeed * 1.2f));
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            objRigidbody.AddForce(new Vector2(0f, -movementSpeed * 0.8f));
        }
    }

    public IEnumerator DisappearObjectCoroutine()
    {
        while (objSprite != null && objSprite.color.a > 0)
        {
            objSprite.color = new Color(255, 255, 255, objSprite.color.a - Time.deltaTime);
            yield return null;
        }

        if (this != null)
        {
            Destroy(this.gameObject); // :(
        }
    }

    public void OnMouseOver()
    {
        SceneController.mouseOverObject = true;
    }

    private void OnMouseExit()
    {
        SceneController.mouseOverObject = false;
    }
}

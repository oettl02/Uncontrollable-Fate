using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    public Vector2 startPos;

    public float movementSpeed = 10.0f;
    public float jumpSpeed = 5.0f;

    private bool isGrounded = false;

    private int sideMultiplier;
    private int jumpMultiplier;

    public float chance = 0.1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            sideMultiplier = getMultiplier();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            sideMultiplier = getMultiplier();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpMultiplier = getMultiplier();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector2 currentVelocity = rigidBody.velocity;
            rigidBody.velocity = new Vector2(movementSpeed * sideMultiplier, currentVelocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector2 currentVelocity = rigidBody.velocity;
            rigidBody.velocity = new Vector2(-movementSpeed * sideMultiplier, currentVelocity.y);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                Vector2 currentVelocity = rigidBody.velocity;
                rigidBody.velocity = new Vector2(currentVelocity.x, jumpSpeed * jumpMultiplier);
            }
        }

        if (transform.position.y < -5)
        {
            transform.position = startPos;
        }
    }

    int getMultiplier()
    {
        if (Random.Range(0.0f, 1.0f) > chance) { return 1; } else { CameraShake.Instance.shake(1f, 1f); return -1;}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}

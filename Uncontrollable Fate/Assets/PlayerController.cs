using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust;

    public float chance = 0.1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            rb.AddForce(Vector3.up * thrust * getMultiplier());
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * thrust * getMultiplier());
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * thrust * getMultiplier());
        }
    }

    int getMultiplier()
    {
        if (Random.Range(0.0f, 1.0f) > chance) { return 1; } else { return -1; }
    }
}

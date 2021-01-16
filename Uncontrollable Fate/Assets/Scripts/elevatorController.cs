using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevatorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public SpriteRenderer spriteRenderer;

    public int currentSceneNum;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "elevator")
        //{
        //    spriteRenderer.sortingOrder = 4;
        //    animator.SetTrigger("Close");
        //}
        if (collision.gameObject.tag == "elevator")
        {
            SceneManager.LoadScene(currentSceneNum + 1);
        }
            
    }
}

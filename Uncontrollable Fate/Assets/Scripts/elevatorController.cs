using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevatorController : MonoBehaviour
{
    [SerializeField] float waitForSeconds;

    private Animator animator;
    private PlayerController playerMovement;
    private GameObject playerLight;

    private IEnumerator coroutine;

    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("elevator").GetComponent<Animator>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerLight = GameObject.FindGameObjectWithTag("playerLight");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered" + collision.gameObject.name);
        if (collision.gameObject.name.Equals("GameObject"))
        {
            Destroy(playerLight);
            playerMovement.enabled = false;
            animator.SetTrigger("Close");
            coroutine = nextLevel(waitForSeconds);
            StartCoroutine(coroutine);
        }

    }

    private IEnumerator nextLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

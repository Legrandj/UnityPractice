using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DasterLookingPlayer : MonoBehaviour
{
    public Player player;
    public SpriteRenderer questionMark;
    Animator animator;
    public Animator transition;
    public float delayUponIdle = 0.5f;
    float speed;
    bool isSpottedByDaster = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = GetComponent<Pathing>().speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isSpottedByDaster && player.transform.position.x >= transform.position.x)
        {
            spottedByDaster();
        }

    }
    void spottedByDaster()
    {
        Pathing pathing = GameObject.FindObjectOfType(typeof(Pathing)) as Pathing;
        pathing.StopAllCoroutines();
        isSpottedByDaster = true;
        notifyAnimator();
        player.canMove = false;
        questionMark.enabled = true;

        speed = speed * 2;
        StartCoroutine("MoveTowardsPlayer");

    }

    public void notifyAnimator()
    {
        transition.SetBool("LoadingNextScene", true);
        player.animator.SetFloat("Speed", 0);
    }
    public IEnumerator MoveTowardsPlayer()
    {
        if (transform.position.y > player.transform.position.y)
        {
            animator.SetBool("MovingUp", false);
        }
        else
        {
            animator.SetBool("MovingUp", true);
        }

        while (Vector3.Distance(transform.position, player.transform.position) > ((GetComponent<BoxCollider2D>().size.y) / 2) + player.GetComponent<BoxCollider2D>().size.y / 2 + 0.05)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            yield return null;
        }
        animator.SetBool("isMoving", false);

        yield return new WaitForSeconds(delayUponIdle);
        callLevelLoader();


    }
    public void callLevelLoader()
    {
        LevelLoaderScript levelLoaderScript = GameObject.FindObjectOfType(typeof(LevelLoaderScript)) as LevelLoaderScript;
        levelLoaderScript.LoadLevel(1);
    }

}
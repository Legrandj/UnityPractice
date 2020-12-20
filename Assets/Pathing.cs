using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    public float speed;
    public Transform pathHolder;
    public Animator animator;
    public Player player;
    [HideInInspector] public Coroutine currentCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
        }
        transform.position = waypoints[0];
        currentCoroutine = StartCoroutine(FollowPath(waypoints));
    }
    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                if (animator != null)
                {
                    animator.SetBool("MovingUp", !animator.GetBool("MovingUp"));
                }
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return null;
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}

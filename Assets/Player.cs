using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    public float speed;
    public Animator animator;
    Vector2 movement;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (canMove)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            rigidBody2D.MovePosition(movement.normalized * speed * Time.fixedDeltaTime + rigidBody2D.position);
        }

    }
}

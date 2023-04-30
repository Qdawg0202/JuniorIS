using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        speed = 5;
    }

    void Update()
    {
        TakeInput();
        Move();
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(direction.x != 0 || direction.y != 0)
        {
            setDir(direction);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void setDir(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDir", direction.x);
    }
}

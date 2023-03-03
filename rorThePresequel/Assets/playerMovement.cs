using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    //private because this is only necessary for it to be accessed by player
    public int jumpMaxCount;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //For easier reference to the RigidBody2d component can just add .rd instead of whole name
        jumpMaxCount = 2;
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && jumpMaxCount > 0)
        {
            rb.velocity = new Vector2(0, 7);
            jumpMaxCount = jumpMaxCount - 1;
        }
        
    }
}

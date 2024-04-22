using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float boostSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            Player1Control();
        }
    }

    private void Player1Control()
    {
        float horizontalInput = 0f;
        float currentMovementSpeed = movementSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }
        

        playerMove = new Vector2(horizontalInput, 0);
    }  
    
    private void AIControl()
    {
        if (ball.transform.position.x > transform.position.x + 0.5f)
        {
            playerMove = new Vector2(1, 0);
        }
        else if (ball.transform.position.x < transform.position.x - 0.5f)
        {
            playerMove = new Vector2(-1, 0);
        }
        else
        {
            playerMove = Vector2.zero;
        }
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = playerMove * boostSpeed;


        }
        else
        rb.velocity = playerMove * movementSpeed;
    }
}

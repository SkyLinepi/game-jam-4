using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
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
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
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
        rb.velocity = playerMove * movementSpeed;
    }
}

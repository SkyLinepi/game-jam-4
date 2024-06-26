using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float boostSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;
    [SerializeField]     [Range(0f, 180f)]     float MaxBallAngle;

    private Rigidbody2D rb;
    private Vector2 player2Move;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ball == null)
        {
            return;
        }
        if (isAI)
        {
            AIControl();
        }
        else
        {
            Player2Control();
        }
    
    }

    private void Player2Control()
    {
        float horizontal2Input = 0f;
        float currentMovementSpeed = movementSpeed;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal2Input = 1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal2Input = -1f;
        }
        player2Move = new Vector2(horizontal2Input, 0); 
    }

    private void AIControl()
    {
        if (ball.transform.position.x > transform.position.x + 0.5f)
        {
            player2Move = new Vector2(1, 0);
        }
        else if (ball.transform.position.x < transform.position.x - 0.5f)
        {
            player2Move = new Vector2(-1, 0);
        }
        else
        {
            player2Move = Vector2.zero;
        }
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = player2Move * boostSpeed;


        }
        else
            rb.velocity = player2Move * movementSpeed;
    }
    void OnCollisionEnter2D(Collision2D ballin)
    {
        if(ballin.gameObject.tag == "ball")
        {

        
         Vector2 ballPos = ballin.transform.position;
        Vector2 playerPos = transform.position;

        float BPDis = ballPos.x - playerPos.x; //Ball - Player Distance
        float BPRatio = BPDis / (this.transform.localScale.x / 2);
        float DirX = (BPRatio * MaxBallAngle) / 180f;

        Vector2 DirToApply = new(DirX, 1 - Mathf.Abs(DirX));
        }
    }
}


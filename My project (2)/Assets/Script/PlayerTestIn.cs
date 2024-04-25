using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestIn : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float boostSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball; // Prefab of the ball
    [SerializeField][Range(0f, 180f)] float MaxBallAngle;

    private Rigidbody2D rb;
    private Vector2 playerMove;
    private GameObject attachedBall; // Reference to the attached ball
    public bool Skill1istrue = false;

    void Start()
    {
        ball = GameObject.FindWithTag("ball");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Player1Control();

       if (Input.GetKeyDown(KeyCode.Alpha1)) // Check if attachedBall is not null
        {
            Debug.Log("press 1");
            Skill1istrue = true;
        }

        
    }

    private void Player1Control()
    {
        float horizontalInput = 0f;
        float currentMovementSpeed = movementSpeed;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = 1f;
        }
        playerMove = new Vector2(horizontalInput, 0);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            rb.velocity = playerMove * boostSpeed;
        }
        else
            rb.velocity = playerMove * movementSpeed;
    }

    void OnCollisionEnter2D(Collision2D ballin)
    {
        if (ballin.gameObject.CompareTag("ball"))
        {
            attachedBall = ballin.gameObject; // Store reference to the attached ball
            Vector2 ballPos = ballin.transform.position;
            Vector2 playerPos = transform.position;

            float BPDis = ballPos.x - playerPos.x; // Ball - Player Distance
            float BPRatio = BPDis / (transform.localScale.x / 2);
            float DirX = (BPRatio * MaxBallAngle) / 180f;

            Vector2 DirToApply = new Vector2(DirX, 1 - Mathf.Abs(DirX));
            DirToApply = DirToApply.normalized;
            BallMovement ballz = ballin.gameObject.GetComponent<BallMovement>();
            ballz.SetDirection(DirToApply);
        }
        if (Skill1istrue && attachedBall != null)
        {
            SplitBall();
        }

    }

    private void SplitBall()
    {
        Debug.Log("Split");
        // Instantiate two new balls at the position of the attached ball
        GameObject newBall1 = Instantiate(ball, attachedBall.transform.position, Quaternion.identity);
        GameObject newBall2 = Instantiate(ball, attachedBall.transform.position, Quaternion.identity);

        // Get the Rigidbody2D components of the new balls
        Rigidbody2D rb1 = newBall1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = newBall2.GetComponent<Rigidbody2D>();

        // Set the velocities of the new balls to be in opposite directions
        rb1.velocity = new Vector2(-1, 1).normalized * attachedBall.GetComponent<BallMovement>().speed;
        rb2.velocity = new Vector2(1, 1).normalized * attachedBall.GetComponent<BallMovement>().speed;

        // Set tags for the new balls
        newBall1.tag = "ball";
        newBall2.tag = "fakeball";

        // Destroy the attached ball
        Destroy(attachedBall);
        attachedBall = null;
        Skill1istrue = false;
    }
}


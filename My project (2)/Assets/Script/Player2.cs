using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float boostSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;
    [SerializeField][Range(0f, 180f)] float MaxBallAngle;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    public bool isskill2 = false;

    bool isPausing = false;

    [SerializeField] private AniManager AniM;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPausing)
            return;
            Player1Control();
    }
    private void OnEnable()
    {
        AniM.onAniPlayed += Pause;
        AniM.onAniFinished += Unpause;
    }

    private void OnDisable()
    {
        AniM.onAniPlayed -= Pause;
        AniM.onAniFinished -= Unpause;
    }

    void Pause()
    {
        playerMove = Vector2.zero;
        isPausing = true;
    }

    void Unpause()
    {
        isPausing = false;
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
        if (isskill2)
        {
            horizontalInput = -horizontalInput;
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
        if (ballin.gameObject.tag == "ball")
        {


            Vector2 ballPos = ballin.transform.position;
            Vector2 playerPos = transform.position;

            float BPDis = ballPos.x - playerPos.x; //Ball - Player Distance
            float BPRatio = BPDis / (this.transform.localScale.x / 2);
            float DirX = (BPRatio * MaxBallAngle) / 180f;

            Vector2 DirToApply = new(DirX, -(1 - Mathf.Abs(DirX)));
            DirToApply = DirToApply.normalized;
            BallMovement ballz = ballin.gameObject.GetComponent<BallMovement>();
            ballz.SetDirection(DirToApply);
        }
    }
}

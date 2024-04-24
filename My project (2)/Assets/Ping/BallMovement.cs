using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] LayerMask ballLayer;

    public float speed;
    public Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        if (SetScore.score1Previous != SetScore.scoreP1)
        {
            SetDirectiond2();
            SetScore.score1Previous++;
        }
        else if (SetScore.score2Previous != SetScore.scoreP2)
        {
            SetDirectiond1();
            SetScore.score2Previous++;
        }
        else
        {
            Launch();
        }

        Physics2D.IgnoreLayerCollision(6, 6, true);
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 dirs = new Vector2(x, y);
        dirs = dirs.normalized;
        rb.velocity = dirs * speed;
    }

    public void SetDirectiond1()
    {
        Vector2 dir = new Vector2(0, -1);
        rb.velocity = dir * speed;
    }

    public void SetDirectiond2()
    {
        Vector2 dir = new Vector2(0, 1);
        rb.velocity = dir * speed;
    }

    public void SetDirection(Vector2 dir)
    {
        rb.velocity = dir * speed;
    }
}


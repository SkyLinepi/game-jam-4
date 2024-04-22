using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public SetScore setscore;
    private Rigidbody2D rb;

    private float countdown = 2;
    private float elaptime = 0;
    private bool goal1;
    private bool goal2;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Resetball()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        Invoke("StartBall", 2f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "colP1")
        {
            Debug.Log("Detect colP1");
            setscore.GetScoreP1 = true;
            Resetball();
            goal1 = true;
        }

        if (col.gameObject.tag == "colP2")
        {
            Debug.Log("Detect colP2");
            setscore.GetScoreP2 = true;
            Resetball();
            goal2 = true;
        }
    }
    void update ()
    {
        if (countdown >= 0)
        {
            elaptime -= Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            
            if (goal1)
            {
                rb.velocity = new Vector2(0, 0);
            }
        }

    }
}

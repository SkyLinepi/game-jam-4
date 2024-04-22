using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colP1 : MonoBehaviour
{
    public SetScore setscore;
    private Rigidbody2D rb;

    private float countdown = 2;
    private float elaptime = 0;
    private bool goal1;
    private bool goal2;

    public gameObject ball;

    void Start()
    {
        
    }
    
        
        void OnTriggerEnter2D(Collider2D col)
    {
        if (this.gameObject.tag == "colP1" && col.gameObject.tag == "ball")
        {
            Debug.Log("Detect colP1");
            setscore.GetScoreP2 = true;
            //Resetball();
            //goal1 = true;
            GameObject.Destroy(col.gameObject);

        }
        if (this.gameObject.tag == "colP2" && col.gameObject.tag == "ball")
        {
            Debug.Log("Detect colP2");
            setscore.GetScoreP1 = true;
            //Resetball();
            //goal2 = true;
            GameObject.Destroy(col.gameObject);
        }
    }



    void update()
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

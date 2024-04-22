using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public SetScore setscore;
    private Rigidbody2D rb;

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
        }

        if (col.gameObject.tag == "colP2")
        {
            Debug.Log("Detect colP2");
            setscore.GetScoreP2 = true;
            Resetball();
        }
    }
}

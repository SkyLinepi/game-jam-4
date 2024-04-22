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
    public GameObject reference;
    public bool ballin;
    public GameObject ball;

    void Start()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (this.gameObject.tag == "colP1" && col.gameObject.tag == "ball")
        {
            Debug.Log("Detect colP1");
            setscore.GetScoreP2 = true;
            GameObject.Destroy(col.gameObject);
            elaptime = countdown; // Reset the countdown timer
            ballin = true;
        }
        if (this.gameObject.tag == "colP2" && col.gameObject.tag == "ball")
        {
            Debug.Log("Detect colP2");
            setscore.GetScoreP1 = true;
            GameObject.Destroy(col.gameObject);
            elaptime = countdown; // Reset the countdown timer
            ballin = true;
        }
    }

    void Update()
    {
        if (elaptime > 0 && ballin)
        {
            Debug.Log("sky");
            elaptime -= Time.deltaTime; // Decrease the countdown timer
        }
        else if(ballin)
        {
            Debug.Log("spawn");
            Instantiate(ball, reference.transform.position, Quaternion.identity);
            elaptime = countdown; // Reset the countdown timer for the next ball
            ballin = false;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class colP1 : MonoBehaviour
{
    public Skill1Player2 skill1player2;
    public SetScore setscore;
    private Rigidbody2D rb;

    private float countdown = 2;
    private float elaptime = 0;
    public bool goal1;
    public bool goal2;
    public GameObject reference;
    public bool ballin;
    public GameObject ball;

    public bool first;

    [SerializeField] AniManager AniM;
    bool isPausing = false;

    void Awake()
    {
        first = true;
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
        isPausing = true;
    }

    void Unpause()
    {
        isPausing = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isPausing)
            return;
        if (this.gameObject.tag == "colP1" && col.gameObject.tag == "ball")
        {
            Debug.Log("Detect colP1");
            setscore.GetScoreP2 = true;
            GameObject.Destroy(col.gameObject);
            elaptime = countdown; // Reset the countdown timer
            ballin = true;
            goal1 = true;
        }
        else if (this.gameObject.tag == "colP2" && col.gameObject.tag == "ball")
        {
            Debug.Log("Detect colP2");
            setscore.GetScoreP1 = true;
            GameObject.Destroy(col.gameObject);
            elaptime = countdown; // Reset the countdown timer
            ballin = true;
            goal2 = true;
        }

        first = false;
    }

    void Update()
    {
        if (isPausing)
            return;
        if (elaptime > 0 && ballin)
        {
            elaptime -= Time.deltaTime; // Decrease the countdown timer
        }
        else if(ballin)
        {
            GameObject SpawnBall = Instantiate(ball, reference.transform.position, Quaternion.identity);
            skill1player2.StartFollow(SpawnBall.transform);
            elaptime = countdown; // Reset the countdown timer for the next ball
            ballin = false;
        }
    }
}


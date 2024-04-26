using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBallScript : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] private float minXVel;
    [Range(-1,1)]
    [SerializeField] private float maxXVel;
    [SerializeField] private float speed;

    private Rigidbody2D rb2;

    private AniManager AniM;

    private Vector2 CurretVel;

    private void Awake()
    {
        AniM = FindAnyObjectByType<AniManager>();
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
        CurretVel = this.rb2.velocity;
        rb2.velocity = Vector2.zero;
    }

    void Unpause()
    {
        rb2.velocity = CurretVel;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        FakeBallDir();
    }

    // Update is called once per frame
    void FakeBallDir()
    {
        float randXVel = Random.Range(minXVel, maxXVel);

        Vector2 dirVector = new Vector2(randXVel, 1 - Mathf.Abs(randXVel));

        dirVector = dirVector.normalized;
        Vector2 speedToApply = dirVector * speed;
        rb2.velocity = speedToApply;
    }
}

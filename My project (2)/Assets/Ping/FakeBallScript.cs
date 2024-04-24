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

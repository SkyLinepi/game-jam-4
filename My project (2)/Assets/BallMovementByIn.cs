using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementByIn : MonoBehaviour
{
    
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Launch();
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

    public void SetDirection(Vector2 dir)
    {
        rb.velocity = dir * speed;
    }
}

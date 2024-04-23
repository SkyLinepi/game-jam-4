using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDestroy : MonoBehaviour
{
    [SerializeField] private string Border;

    void OnCollisionEnter2D(Collision2D ballin)
    {
        if (ballin.gameObject.name != Border)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != Border)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}

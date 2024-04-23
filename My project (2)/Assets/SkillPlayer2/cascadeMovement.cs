using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cascadeMovement : MonoBehaviour
{
    [SerializeField] float Speed;

    void Update()
    {
        transform.Translate(new Vector2(-Speed, 0) * Time.deltaTime);
        return;
    }
}

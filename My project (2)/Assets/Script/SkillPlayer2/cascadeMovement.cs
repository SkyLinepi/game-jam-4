using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cascadeMovement : MonoBehaviour
{
    [SerializeField] float Speed;

    void Update()
    {
        transform.Translate(new Vector2(0, Speed) * Time.deltaTime , Space.Self);
        return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpinScript : MonoBehaviour
{
    [SerializeField] private float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,-Speed*Time.deltaTime));
    }
}

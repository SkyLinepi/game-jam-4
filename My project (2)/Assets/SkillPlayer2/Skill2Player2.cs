using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Player2 : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float cooldownTimer = 0f;


    public GameObject cascade;
    private bool skill2_2 = false;
    [SerializeField] private Vector2 Destination;
    private float Distance;

    void Start()
    {
        
    }

    void Update()
    {
        Distance = -(Destination.y - cascade.transform.position.y);

        if (cooldownTimer > 0 && !cascade.activeSelf)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (Distance <= 0)
        {
            cascade.active = false;
        }

        if (cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.I))
        {
            ActivateSkill();    
        }

        Debug.Log("Distance =" + Distance);
    }


    public void ActivateSkill()
    {
        Debug.Log("Skill2_2");
        cascade.active = true;
        cascade.transform.position = new Vector2(0,9);

        cooldownTimer = cooldownTime; // Start cooldown timer
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float cooldownTimer = 0f;
    public float skillDuration = 4f;
    private float skillTimer = 0f;

    public PlayerMovement PM;

    void Start()
    {
        PM = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.O))
        {
            ActivateSkill();
        }

        if (skillTimer > 0 && PM.isskill2)
        {
            skillTimer -= Time.deltaTime;
        }
        else if (PM.isskill2)
        {
            skillTimer = 0;
            PM.isskill2 = false;
        }
    }
    
    
    public void ActivateSkill()
    {
        Debug.Log("Skill2");
        skillTimer = skillDuration;
        PM.isskill2 = true;
        cooldownTimer = cooldownTime; // Start cooldown timer
    }
}

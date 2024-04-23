using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float cooldownTimer = 0f;
    public float skillDuration = 4f;
    private float skillTimer = 0f;
    [SerializeField] private GameObject FakeBall;
    [SerializeField] private GameObject FakeLocation;
    private Vector2 FakeSpawn;


    private bool isskill1 = false;


    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.I))
        {
            isskill1 = true;
            
            skillTimer = skillDuration;
            cooldownTimer = cooldownTime;
        }

        if (skillTimer > 0 && isskill1)
        {
            
            skillTimer -= Time.deltaTime;

        }
        else if (skillTimer <= 0)
        {
            isskill1 = false;
        }
    }

    public void ActivateSkill()
    {
        Debug.Log("Skill1");
        Debug.Log("Fake Ball skill1");
        Instantiate(FakeBall, FakeSpawn, Quaternion.identity);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        FakeSpawn = col.transform.position;
        if (skillTimer > 0)
        {
            ActivateSkill();
        }
        isskill1 = false;
    }






}

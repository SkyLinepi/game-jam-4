using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill1Player2 : MonoBehaviour
{
    [SerializeField] colP1  ColP1;
    [SerializeField] private Transform SpawnTarget;
    [SerializeField] private Transform BallTarget;
    [SerializeField] private Transform BallPosition;
    [SerializeField] private GameObject Wall;
    [SerializeField] private float WallDuration = 1f;
    private bool isFollowing = false;
    private bool isBallGoingUP = true;
    public float WallOffset;
    private float cooldownTimer;
    [SerializeField] private float cooldownTime = 5f;
    [SerializeField] private bool CanUseSkill1 = true;


    void Start()
    {
        CanUseSkill1 = true;
    }

    
    void Update()
    {
        Timer();
        if(BallPosition == null)
        {
            StopFollow();
            return;
        }

        if(isFollowing)
        {
            BallTarget.position = BallPosition.position;
            SpawnTarget.position = BallPosition.position;
            Vector3 OffsetY;
            if(isBallGoingUP)
            {
                OffsetY = Vector3.up;
            }
            else 
            {
                OffsetY = Vector3.down;
            }
            SpawnTarget.position += OffsetY * WallOffset;
        }

        if(CanUseSkill1 && Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Press I");
            WallSpawn();
            CanUseSkill1 = false;
            cooldownTimer = cooldownTime;
        }
    }
    void Timer()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if(!CanUseSkill1)
        {
            cooldownTimer = 0;
            CanUseSkill1 = true;
        }
    }

    void WallSpawn()
    {
        Debug.Log("WallSpawn");
        GameObject SpawnedWall = Instantiate(Wall, SpawnTarget.position, Quaternion.identity);
        Destroy(SpawnedWall, WallDuration);
    }

    public void StartFollow(Transform Ball)
    {
        BallPosition = Ball;
        isFollowing = true;
    }

    void StopFollow()
    {
        isFollowing = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Image SkillBox;
    [SerializeField] Image SkillIcon;
    [SerializeField] private Animator SkillAni;

    public AudioClip VoiceOver;
    public GameObject EffectSetactive;
    private AudioSource audioSource;

    bool InArea = false;
    [SerializeField] Transform Player2;

    [SerializeField] float AvaiableSkillArea;

    [SerializeField] AniManager AniM;
    bool IsPausing = false;

    public GameObject Cutscenes;

    private GameObject SpawnedWall;
    void Start()
    {
        CanUseSkill1 = true;
        audioSource = GetComponent<AudioSource>();
        SkillAni.SetBool("isCooldown", false);
    }
    void Pause()
    {
        IsPausing = true;
    }

    void Unpause()
    {
        IsPausing = false;
        EffectSetactive.SetActive(true);
        Cutscenes.SetActive(false);
    }

    private void OnEnable()
    {
        AniM.onAniPlayed += Pause;
        AniM.onAniFinished += Unpause;
    }
    private void OnDisable()
    {
        AniM.onAniPlayed -= Pause;
        AniM.onAniFinished -= Unpause;
    }

    void Update()
    {
        if (IsPausing)
            return;
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

            InArea = Mathf.Abs(BallTarget.position.y - Player2.position.y) <= AvaiableSkillArea;
            
        }

        if(CanUseSkill1 && Input.GetKeyDown(KeyCode.I) && InArea)
        {
            Debug.Log("Press I");
            CanUseSkill1 = false;
            cooldownTimer = cooldownTime;
            audioSource.PlayOneShot(VoiceOver);
            StartCoroutine(CutSceneTimer());
            Cutscenes.SetActive(true);
        }
    }
    void Timer()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime; 
            SkillBox.color = Color.gray;
            SkillAni.SetBool("isCooldown", true);
            SkillIcon.color = Color.gray;
        }
        else if(!CanUseSkill1)
        {
            cooldownTimer = 0;
            CanUseSkill1 = true;
            SkillBox.color = Color.white;
            SkillAni.SetBool("isCooldown", false);
            SkillIcon.color = Color.white;
        }
    }

    IEnumerator WallSpawn()
    {
        yield return null;
        Debug.Log("WallSpawn");
        GameObject SpawnedWall = Instantiate(Wall, SpawnTarget.position, QuaternionCal());
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

    Quaternion QuaternionCal()
    {
        Vector2 BallDir = BallPosition.gameObject.GetComponent<Rigidbody2D>().velocity;
        if(BallDir.y < 0)
        {
            return Quaternion.identity;
        }
        BallDir = BallDir.normalized;
        Vector2 Dir = BallDir - Vector2.up;
        float AngleInRad = Mathf.Atan2(Dir.y, Dir.x);
        Quaternion RotationToApply = Quaternion.Euler(0,0,AngleInRad * Mathf.Rad2Deg);
        return RotationToApply;
    }
    IEnumerator CutSceneTimer()
    {
        AniM.AniPlay();
        yield return new WaitForSeconds(3);
        AniM.AniFin();
        StartCoroutine(WallSpawn());
    }
}

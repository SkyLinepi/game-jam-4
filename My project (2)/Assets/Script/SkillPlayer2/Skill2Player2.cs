using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill2Player2 : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float cooldownTimer = 0f;


    public GameObject cascade;
    private bool skill2_2 = false;
    [SerializeField] private Vector2 Destination;
    private float Distance;

    public AudioClip VoiceOver;
    public GameObject EffectSetactive;
    private AudioSource audioSource;

    [SerializeField] Image SkillBox;
    [SerializeField] Image SkillIcon;
    [SerializeField] private Animator SkillAni;

    [SerializeField] AniManager AniM;
    bool IsPausing = false;

    public GameObject Cutscenes;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Pause()
    {
        IsPausing = true;
        Cutscenes.SetActive(true);
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
        Distance = -(Destination.y - cascade.transform.position.y);

        if (cooldownTimer > 0 && !cascade.activeSelf)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (Distance <= 0)
        {
            cascade.active = false;
        }
        
        if(cooldownTimer > 0)
        {
            SkillBox.color = Color.gray;
            SkillAni.SetBool("isCooldown", true);
            SkillIcon.color = Color.gray;
        }
        else if(cooldownTimer <= 0)
        {
            SkillBox.color = Color.white;
            SkillAni.SetBool("isCooldown", false);
            SkillIcon.color = Color.white;
        }

        if (cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.O))
        {
            ActivateSkill();
            StartCoroutine(CutSceneTimer());
            audioSource.PlayOneShot(VoiceOver);
        }

        Debug.Log("Distance =" + Distance);
    }


    public void ActivateSkill()
    {
        Debug.Log("Skill2_2");
        cascade.active = true;
        cascade.transform.position = transform.position;

        cooldownTimer = cooldownTime; // Start cooldown timer
    }
    IEnumerator CutSceneTimer()
    {
        AniM.AniPlay();
        yield return new WaitForSeconds(3);
        AniM.AniFin();
    }
}

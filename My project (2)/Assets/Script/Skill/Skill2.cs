using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill2 : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float cooldownTimer = 0f;
    public float skillDuration = 4f;
    private float skillTimer = 0f;
    public AudioClip VoiceOver;
    public GameObject EffectSetactive;
    private AudioSource audioSource;
    public Player2 PM;
    public GameObject target;

    [SerializeField] private Image SkillBox;
    [SerializeField] private Animator SkillAni;
    [SerializeField] private Image SkillIcon;

    void Start()
    {
        PM = target.GetComponent<Player2>();
        audioSource = GetComponent<AudioSource>();
        SkillAni.SetBool("isCooldown", false);

    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            SkillBox.color = Color.gray;
            SkillAni.SetBool("isCooldown", true);
            SkillIcon.color = Color.gray;
        }
        else if (cooldownTimer <= 0)
        {
            SkillBox.color = Color.white;
            SkillAni.SetBool("isCooldown", false);
            SkillIcon.color = Color.white;
        }

        if (cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateSkill();
            EffectSetactive.SetActive(true);
        }

        if (skillTimer > 0 && PM.isskill2)
        {
            skillTimer -= Time.deltaTime;
        }
        else if (PM.isskill2)
        {
            skillTimer = 0;
            PM.isskill2 = false;
            EffectSetactive.SetActive(false);
        }
    }
    
    
    public void ActivateSkill()
    {
        Debug.Log("Skill2");
        skillTimer = skillDuration;
        PM.isskill2 = true;
        cooldownTimer = cooldownTime; // Start cooldown timer
        audioSource.Stop();
        audioSource.PlayOneShot(VoiceOver);
    }
}

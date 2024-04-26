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
    public GameObject ParticleS2P1;
    public GameObject QuestionMark;

    [SerializeField] private Image SkillBox;
    [SerializeField] private Animator SkillAni;
    [SerializeField] private Image SkillIcon;

    [SerializeField] AniManager AniM;
    bool IsPausing = false;

    public GameObject Cutscenes;

    void Start()
    {
        PM = target.GetComponent<Player2>();
        audioSource = GetComponent<AudioSource>();
        SkillAni.SetBool("isCooldown", false);
    }

    void Pause()
    {
        IsPausing = true;
        Cutscenes.SetActive(true);
    }

    void Unpause()
    {
        IsPausing = false; 
        ParticleS2P1.active = true;
        QuestionMark.active = true;
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
            ParticleS2P1.active = false;
            ParticleS2P1.transform.position= new Vector3(0,-10,0);
            QuestionMark.active = false;
        }

        if (cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateSkill();
            StartCoroutine(CutSceneTimer());
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
    IEnumerator CutSceneTimer()
    {
        AniM.AniPlay();
        yield return new WaitForSeconds(3);
        AniM.AniFin();
    }
}

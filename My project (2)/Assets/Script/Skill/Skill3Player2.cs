using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill3Player2 : MonoBehaviour
{
    public bool isOnCooldown = false;
    public float cooldownDuration = 20f; // Cooldown duration in seconds
    public float cooldownTimer = 0f;

    private float debuffDuration = 10f; // Debuff duration in seconds
    private float debuffTimer = 0f;

    public AudioClip VoiceOver;
    public GameObject EffectSetactive;
    private AudioSource audioSource;

    [SerializeField] Image SkillBox;
    [SerializeField] Image SkillIcon;
    [SerializeField] private Animator SkillAni;

    [SerializeField] AniManager AniM;
    bool IsPausing = false;

    public GameObject[] Cutscenes;
    [SerializeField] private int i;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Pause()
    {
        IsPausing = true;
    }

    void Unpause()
    {
        IsPausing = false;
        Cutscenes[i].SetActive(false);
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
        // Update debuff timer if the player is debuffed
        if (PlayerMovement.isDebuffed)
        {
            debuffTimer -= Time.deltaTime;
            if (debuffTimer <= 0)
            {
                PlayerMovement.isDebuffed = false; // Reset the debuff status
                EffectSetactive.SetActive(false);
            }
        }

        // Activate the skill if it's not on cooldown and the player is not debuffed
        if (!isOnCooldown && Input.GetKeyDown(KeyCode.P))
        {
            ActivateSkill();
            StartCoroutine(CutSceneTimer());
            audioSource.PlayOneShot(VoiceOver);
            Cutscenes[i].SetActive(true);
        }

        // Update cooldown timer if the skill is on cooldown
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            SkillBox.color = Color.gray;
            SkillAni.SetBool("isCooldown", true);
            SkillIcon.color = Color.gray;
            if (cooldownTimer <= 0)
            {
                isOnCooldown = false;
                SkillBox.color = Color.white;
                SkillAni.SetBool("isCooldown", false);
                SkillIcon.color = Color.white;
            }
        }
    }

    private void ActivateSkill()
    {
        i = Random.Range(0, 3);
        PlayerMovement.isDebuffed = true;
        debuffTimer = debuffDuration; // Start the debuff timer
        isOnCooldown = true;
        cooldownTimer = cooldownDuration; // Start the cooldown timer
    }
    IEnumerator CutSceneTimer()
    {
        AniM.AniPlay();
        yield return new WaitForSeconds(3);
        AniM.AniFin();
        EffectSetactive.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            EffectSetactive.SetActive(true);
            audioSource.PlayOneShot(VoiceOver);
        }

        // Update cooldown timer if the skill is on cooldown
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                isOnCooldown = false;
            }
        }
    }

    private void ActivateSkill()
    {
        PlayerMovement.isDebuffed = true;
        debuffTimer = debuffDuration; // Start the debuff timer
        isOnCooldown = true;
        cooldownTimer = cooldownDuration; // Start the cooldown timer
    }
}

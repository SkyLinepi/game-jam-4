using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float cooldownTimer = 0f;
    public float skillDuration = 4f;
    private float skillTimer = 0f;
    [SerializeField] private GameObject Cam1;
    [SerializeField] private float RotationSpeed = 0;

   private bool isskill3 = false;
   public AudioClip VoiceOver;
    public GameObject EffectSetactive;
    private AudioSource audioSource;
    private bool yoyoyo;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            isskill3 = true;
            skillTimer = skillDuration;
            cooldownTimer = cooldownTime;
            yoyoyo = true;
        }

        if (skillTimer > 0 && isskill3)
        {
            ActivateSkill();
            skillTimer -= Time.deltaTime;
            
        }
        else if (isskill3)
        {
            isskill3 = false;
            Cam1.transform.rotation = Quaternion.identity;
            EffectSetactive.SetActive(false);
        }
        if(yoyoyo){
            audioSource.PlayOneShot(VoiceOver);
            yoyoyo = false;
        }
        
    }


    public void ActivateSkill()
    {
        
        Debug.Log("Skill3");
        Cam1.transform.Rotate(new Vector3(0, 0, RotationSpeed) * Time.deltaTime);
        EffectSetactive.SetActive(true);
    }
}

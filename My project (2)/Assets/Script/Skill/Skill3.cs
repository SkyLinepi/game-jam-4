using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill3 : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float cooldownTimer = 0f;
    public float skillDuration = 4f;
    private float skillTimer = 0f;
    [SerializeField] private GameObject Campivot;
    [SerializeField] private GameObject Cam;
    [SerializeField] private float RotationSpeed = 0;

    [SerializeField] private Image SkillBox;
    [SerializeField] private Animator SkillAni;
    [SerializeField] private Image SkillIcon;

    private bool isskill3 = false;
   public AudioClip VoiceOver;
    public GameObject EffectSetactive;
    private AudioSource audioSource;
    private bool yoyoyo;

    [SerializeField] private float MinFOV;
    [SerializeField] private float MaxFOV;
    private float t;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Cam.GetComponent<Camera>().fieldOfView = 43.1f;
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
            Campivot.transform.rotation = Quaternion.identity;
            EffectSetactive.SetActive(false);
            Cam.GetComponent<Camera>().fieldOfView = 41.3f;
        }
        if(yoyoyo)
        {
            audioSource.PlayOneShot(VoiceOver);
            yoyoyo = false;
        }
        
    }


    public void ActivateSkill()
    {
        
        Debug.Log("Skill3");
        Campivot.transform.Rotate(new Vector3(0, 0, RotationSpeed) * Time.deltaTime);
        EffectSetactive.SetActive(true);
        Cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(MinFOV, MaxFOV, t);
        TCalculater();
    }


    void TCalculater()
    {
        float pivotZ = Campivot.transform.eulerAngles.z;
        pivotZ = Mathf.Abs(pivotZ);

        if (pivotZ < 90)
        {
            t = pivotZ / 90;
        }
        else if (pivotZ < 180)
        {
            t = (180 - pivotZ) / 90;
        }
        else if (pivotZ < 270)
        {
            t = (pivotZ - 180) / 90;
        }
        else if (pivotZ < 360)
        {
            t = (360 - pivotZ) / 90;
        }
        Debug.Log("pivotZ value:" + pivotZ);
    }
}

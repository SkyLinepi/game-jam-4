using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Skill1 : MonoBehaviour
{
    public float cooldownTime = 1f;
    [SerializeField] private float cooldownTimer = 0f;
    public float skillDuration = 4f;
    [SerializeField] private float skillTimer = 0f;
    [SerializeField] private GameObject FakeBall;
    [SerializeField] private GameObject FakeLocation;
    private Vector2 FakeSpawn;
    public GameObject EffectSetactive;
    private AudioSource audioSource;
    [SerializeField] private AudioClip VoiceOver;
    [SerializeField] private AudioClip Spawn;

    [SerializeField] private Image SkillBox;
    [SerializeField] private Animator SkillAni;
    [SerializeField] private Image SkillIcon;

    public GameObject Cutscenes;

    bool IsPausing = false;

    [SerializeField] private bool isskill1 = false;
    public GameObject particleS1P1;

    [SerializeField] AniManager AniM;

    void Start()
    {
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
        //Cutscenes.SetActive(false);
    }

    private void OnEnable()
    {
        AniM.onAniPlayed += Pause;
        AniM.onAniFinished += Unpause;
    }

    void Update()
    {
        

        if (IsPausing)
        {
            return;
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            SkillBox.color = Color.gray;
            SkillAni.SetBool("isCooldown",true);
            SkillIcon.color = Color.gray;
        }
        else if(cooldownTimer <= 0)
        {
            SkillBox.color = Color.white;
            SkillAni.SetBool("isCooldown", false);
            SkillIcon.color = Color.white;
            particleS1P1.active = false;
        }

        if (cooldownTimer <= 0 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            isskill1 = true;
            skillTimer = skillDuration;
            cooldownTimer = cooldownTime;
            audioSource.PlayOneShot(VoiceOver);
            EffectSetactive.SetActive(true);
            //Cutscenes.SetActive(true);
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
    private void OnDisable()
    {
        AniM.onAniPlayed -= Pause;
        AniM.onAniFinished -= Unpause;
    }

    public void ActivateSkill()
    {
        Debug.Log("Skill1");
        Debug.Log("Fake Ball skill1");
        Instantiate(FakeBall, FakeSpawn, Quaternion.identity);
        audioSource.PlayOneShot(Spawn);
        particleS1P1.active = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        FakeSpawn = col.transform.position;
        if (skillTimer > 0 && isskill1)
        {
            ActivateSkill();
            EffectSetactive.SetActive(false);
        }
        isskill1 = false;
    }

    IEnumerator CutSceneTimer()
    {
        AniM.AniPlay();
        yield return new WaitForSeconds(3);
        AniM.AniFin();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class SkillStage : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject BGM;
    public AudioClip[] defaultMusic = new AudioClip[3];
    private float _duration;
    public UnityEvent onFinishSound;
    private bool _isBGM = false;


    private void Awake()
    {            
        StartCoroutine(WaitForSound(0));
    }

    private void Start()
    {
        _isBGM = true;
    }
    public void Initialize(int Index)
    {
        //audioSource.Stop();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = defaultMusic[Index];
        audioSource.Play();
        _duration = defaultMusic[Index].length;
    }
        


    IEnumerator WaitForSound(int Index)
    {
        yield return new WaitUntil(() => audioSource.time >= defaultMusic[Index].length);
        _isBGM = true;
        print("FinishAudio");               
    }


    void Update()
    {
        CheckInput();
        BGM.SetActive(_isBGM);
    }


    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            audioSource.loop = false;
            _isBGM = false;
            Initialize(1);
            StartCoroutine(WaitForSound(1));
            
            return;
        }               
        if (Input.GetKeyDown(KeyCode.P))
        {
            audioSource.loop = false;
            _isBGM = false;

            BGM.SetActive(_isBGM = false);
            Initialize(2);
            StartCoroutine(WaitForSound(2));           
            return;
        }
    }
}
    

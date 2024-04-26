using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cascadeMovement : MonoBehaviour
{
    [SerializeField] float Speed;

    private AniManager AniM;

    private bool isPausing;

    private void Awake()
    {
        AniM = FindAnyObjectByType<AniManager>();  
    }
    void Update()
    {
        if(isPausing)
            return;
        transform.Translate(new Vector2(0, Speed) * Time.deltaTime , Space.Self);
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

    void Pause()
    {
        isPausing = true;
    }

    void Unpause()
    {
        isPausing = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AniManager : MonoBehaviour
{
    public UnityAction onAniPlayed;
    public UnityAction onAniFinished;

    public void AniPlay()
    {
        onAniPlayed?.Invoke();
    }

    public void AniFin()
    {
        onAniFinished?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointeronButton1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator Door;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Door.SetBool("MouseOn" ,true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Door.SetBool("MouseOn" ,false);
    }   
}

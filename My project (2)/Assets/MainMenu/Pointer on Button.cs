using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointeronButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private UnityEngine.UI.Image Arrow;
    [SerializeField] private UnityEngine.UI.Image Arrow2;
    Color AColor;
    public void OnPointerEnter(PointerEventData eventData)
    {
        AColor.r = 255f;
        AColor.b = 255f;
        AColor.g = 255f;
        AColor.a = 255f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AColor.a = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject Child = transform.GetChild(0).gameObject;
        GameObject Child2 = transform.GetChild(1).gameObject;
        Arrow = Child.GetComponent<Image>();
        Arrow2 = Child2.GetComponent<Image>();
        AColor.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Arrow.color = AColor;
        Arrow2.color = AColor;
        if(Arrow != null)
        {
            Debug.Log("Found it");
        }
    }   
}

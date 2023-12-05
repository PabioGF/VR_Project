using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoverTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        onEnter.Invoke();
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onExit.Invoke();
        Debug.Log("Exit");
    }

    public UnityEvent onEnter;
    public UnityEvent onExit;

}

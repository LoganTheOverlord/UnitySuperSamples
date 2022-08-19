using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform toHide;

    void Start()
    {
        toHide.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toHide.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toHide.gameObject.SetActive(false);
    }
}

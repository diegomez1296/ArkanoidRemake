using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UIButtonScaleAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.GetComponent<Button>().interactable)
            this.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.GetComponent<Button>().interactable)
            this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}

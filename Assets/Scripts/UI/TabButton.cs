using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler{
    public TabGroup tabGroup;

    [HideInInspector]public TextMeshProUGUI tabBtnText;

    public UnityEvent onTabSelected;

    public UnityEvent onTabDeselected;
    //public Image

    private void Awake(){
        tabBtnText = GetComponent<TextMeshProUGUI>();
        //tabGroup.Subscribe(this);
    }

    public void OnPointerEnter(PointerEventData eventData){
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerClick(PointerEventData eventData){
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerExit(PointerEventData eventData){
        tabGroup.OnTabExit(this);
    }

    public void Select(){
        onTabSelected?.Invoke();
    }

    public void Deselect(){
        onTabDeselected?.Invoke();
    }
}
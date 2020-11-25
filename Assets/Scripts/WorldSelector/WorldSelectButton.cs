using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;

public class WorldSelectButton : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler, IPointerEnterHandler, IPointerExitHandler{

    //public Text text;
    public TextMeshProUGUI text;
    public Image rect;
    public Image circle;

    public Color textColorWhenSelected;
    public Color rectColorMouseOver;

    public SceneIndex sceneToLoad;
    public Button startSelectedLevelButton;

    private void Awake(){
        startSelectedLevelButton = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Button>();
    }

    private void Start(){
        rect.color = Color.clear;
        text.color = Color.white;
        circle.color = Color.white;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        rect.DOColor(Color.clear, .1f);
        text.DOColor(Color.white, .1f);
        circle.DOColor(Color.white, .1f);
    }

    public void OnSelect(BaseEventData eventData)
    {
        rect.DOColor(Color.white, .1f);
        text.DOColor(textColorWhenSelected, .1f);
        circle.DOColor(Color.red, .1f);

        rect.transform.DOComplete();
        rect.transform.DOPunchScale(Vector3.one / 3, .2f, 20, 1);
        
        //Debug.Log("Clicked");
        startSelectedLevelButton.onClick.AddListener(()=> LoadLevelIndex(sceneToLoad));
    }

    private void LoadLevelIndex(SceneIndex sceneIndex){
        Loader.Load(sceneIndex);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        //Debug.Log("Level Loaded : " + sceneToLoad);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (EventSystem.current.currentSelectedGameObject != gameObject)
        {
            rect.DOColor(rectColorMouseOver, .2f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (EventSystem.current.currentSelectedGameObject != gameObject)
        {
            rect.DOColor(Color.clear, .2f);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour{
    public List<TabButton> tabButtons;

    public List<GameObject> objectsToSwap;
    
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;

    public TabButton selectedTab;

    public void Subscribe(TabButton button){
        if (tabButtons == null){
            tabButtons = new List<TabButton>();
        }
        
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button){
        ResetTabs();
        if (selectedTab == null || button != selectedTab){
            button.tabBtnText.color = tabHover;
        }
    }

    public void OnTabExit(TabButton button){
        ResetTabs();
    }

    public void OnTabSelected(TabButton button){
        if(selectedTab != null)
            selectedTab.Deselect();
        
        selectedTab = button;
        
        selectedTab.Select();
        
        ResetTabs();
        button.tabBtnText.color = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++){
            if (i == index){
                objectsToSwap[i].SetActive(true);
            }
            else{
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    void ResetTabs(){
        foreach (TabButton tabButton in tabButtons){
            if(selectedTab!=null && tabButton == selectedTab)
                continue;
            
            tabButton.tabBtnText.color = tabIdle;
        }    
    }

    private void Start(){
        OnTabSelected(tabButtons[0]);//select first tab by default
    }
}
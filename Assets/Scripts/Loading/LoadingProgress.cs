using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgress : MonoBehaviour{
    private Image loadingProgressBar;

    private void Awake(){
        loadingProgressBar = transform.GetComponent<Image>();
    }

    private void Update(){
        loadingProgressBar.fillAmount = Loader.LoadingProgress();
    }
}
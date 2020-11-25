using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour{

    public bool dontDestroyOnLoad;
    private void Awake(){
        if(dontDestroyOnLoad)
            DontDestroyOnLoad(this.gameObject);
    }
}
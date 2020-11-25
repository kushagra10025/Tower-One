using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOAD_SCENE_WITHNAME : MonoBehaviour{

    public void LoadLevelOf(int index){
        Loader.Load((SceneIndex) index);
    }
}
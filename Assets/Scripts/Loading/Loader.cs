using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader{

    private class LoadingMonoBehaviour : MonoBehaviour{ }

    private static float timeToWaitForScenes = 2.82f;
    
    private static Action onLoaderCallback;
    private static AsyncOperation _asyncOperation;
    
    public static void Load(SceneIndex scene){
        onLoaderCallback = () => {
            GameObject loadingGO = new GameObject("Loading GameObject");
            loadingGO.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneASync(scene));
        };
        SceneManager.LoadScene((int) SceneIndex.LOADING_SCENE);
    }

    private static IEnumerator LoadSceneASync(SceneIndex scene){
        //yield return null;
        yield return new WaitForSeconds(timeToWaitForScenes);
        _asyncOperation = SceneManager.LoadSceneAsync((int) scene);
        while (!_asyncOperation.isDone){
            yield return null;
        }//Wait for scene to load
    }

    public static float LoadingProgress(){
        if (_asyncOperation != null){
            return _asyncOperation.progress;
        }
        else{
            return 1f;
        }
    }

    public static void LoaderCallback(){
        if (onLoaderCallback != null){
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
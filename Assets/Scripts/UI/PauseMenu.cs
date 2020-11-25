using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour{

    private bool paused;
    public GameObject pauseMenu;

    
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (paused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        paused = true;
        //StartCoroutine(SetTimeScale(0.0f));
    }

    public void ExitToMainMenu(){
        Time.timeScale = 1.0f;
        Loader.Load(SceneIndex.WORLD_SELECTOR);
    }

    public void Quit(){
        Application.Quit();
    }

    IEnumerator SetTimeScale(float timeScale){
        yield return new WaitForSeconds(1f);
        Time.timeScale = timeScale;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour{

    public AudioMixer mainMixer;

    public TMP_Dropdown resolutionDropDown;
    
    private Resolution[] _resolutions;
    
    private void Start(){
        _resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++){
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
                currentResIndex = i;
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetResolution(int resIndex){
        Resolution res = _resolutions[resIndex];
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
    }

    public void SetMasterVolume(float masterVolume){
        //Slider ranges from -80 to 0 db
        mainMixer.SetFloat("masterVolume", masterVolume);
    }

    public void SetMusicVolume(float musicVolume){
        mainMixer.SetFloat("musicVolume", musicVolume);
    }

    public void SetSFXVolume(float sfxVolume){
        mainMixer.SetFloat("sfxVolume", sfxVolume);
    }
    

    public void SetQualitySettings(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen = " + isFullscreen);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void LoadWorldSelector(){
        StartCoroutine("LoadWSLevel");
    }

    IEnumerator LoadWSLevel(){
        yield return new WaitForSeconds(2f);
        Loader.Load(SceneIndex.WORLD_SELECTOR);
    }
}
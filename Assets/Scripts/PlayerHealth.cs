using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class PlayerHealth : MonoBehaviour{
    public HealthSystem playerHealthSystem;

    public Image healthUI;

    private PlayerController _playerController;

    private void Awake(){
        playerHealthSystem = new HealthSystem();
        _playerController = GetComponent<PlayerController>();
        healthUI = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Image>();
    }

    private void OnEnable(){
        if (playerHealthSystem != null){
            playerHealthSystem.OnHealthChanged += PlayerHealthSystemOnOnHealthChanged;
            playerHealthSystem.OnDeath += PlayerHealthSystemOnOnDeath;
        }
    }
    
    private void OnDisable(){
        if (playerHealthSystem != null){
            playerHealthSystem.OnHealthChanged -= PlayerHealthSystemOnOnHealthChanged;
            playerHealthSystem.OnDeath -= PlayerHealthSystemOnOnDeath;
        }
    }
    private void PlayerHealthSystemOnOnHealthChanged(object sender, EventArgs e){
        //When Health is Updated..Reduce or Increase That Logic Goes here
        Debug.Log(playerHealthSystem.GetHealth());
        healthUI.fillAmount = playerHealthSystem.GetHealthPercent();
    }
    
    private void PlayerHealthSystemOnOnDeath(object sender, EventArgs e){
        //Put Death Logic Here
        Debug.Log("Player Is Dead");
        _playerController.SetDeathState(true);
        _playerController.enabled = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyHealth : MonoBehaviour{
    public int enemyUnitMaxHealth = 100;
    public HealthSystem enemyHealthSystem;

    private EnemyController _enemyController;
    private bool isDead;
    private void Awake(){
        enemyHealthSystem = new HealthSystem(enemyUnitMaxHealth);
        _enemyController = GetComponent<EnemyController>();
    }

    private void OnEnable(){
        if (enemyHealthSystem != null){
            enemyHealthSystem.OnHealthChanged += EnemyHealthSystemOnOnHealthChanged;
            enemyHealthSystem.OnDeath += EnemyHealthSystemOnOnDeath;
        }
    }
    
    private void OnDisable(){
        if (enemyHealthSystem != null){
            enemyHealthSystem.OnHealthChanged -= EnemyHealthSystemOnOnHealthChanged;
            enemyHealthSystem.OnDeath -= EnemyHealthSystemOnOnDeath;
        }
    }
    
    
    private void EnemyHealthSystemOnOnHealthChanged(object sender, EventArgs e){
        Debug.Log("Enemy Health : " + enemyHealthSystem.GetHealth());
    }
    
    private void EnemyHealthSystemOnOnDeath(object sender, EventArgs e){
        Debug.Log("Enemy is Dead");
        _enemyController.enabled = false;
        isDead = true;
        gameObject.SetActive(false);
    }

    public bool GetIsDead(){
        return isDead;
    }
}
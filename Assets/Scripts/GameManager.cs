using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    private static GameManager _instance;
    
    public static GameManager Instance{
        get => _instance;
    }

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject towerPrefab;

    public CinemachineVirtualCamera playerCamera;

    private PlayerHealth player;
    private EnemyHealth enemy;
    private TowerEnemyLocator tEL;

    private Transform playerSpawn;
    private Transform towerSpawn;
    private GameObject[] enemySpawns;

    private PlayerInputActions pla;

    private void Awake(){
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;

        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        enemySpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        towerSpawn = GameObject.FindGameObjectWithTag("TowerSpawn").transform;
        pla= new PlayerInputActions();
    }

    private void Start(){
        SpawnPlayer();
        //SpawnEnemies();
    }

    //SPAWN ENEMIES WAS HERE -> MOVED TO WAVE SPAWNER

    private void SpawnPlayer(){
        GameObject pla = Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
        player = pla.GetComponent<PlayerHealth>();
        playerCamera.Follow = pla.transform;
        playerCamera.LookAt = pla.transform;
        GameObject tow = Instantiate(towerPrefab, towerSpawn.position, towerSpawn.rotation);
        tEL = tow.GetComponent<TowerEnemyLocator>();
    }
    
    //TODO: Check for any property set via inspector and convert that to code.
    //TODO: Wave Manager & Enemy Spawner -> Partially Done
    //TODO: Fix Bugs

    private void OnEnable(){
        pla.Enable();
        pla.Debug.IncreaseHealth.performed += IncreasePlayerHealth;
        pla.Debug.IncreaseEnemyHealth.performed += IncreaseEnemyHealth;
        pla.Debug.IncreaseRadius.performed += IncreaseRadius;
        pla.Debug.ReduceHealth.performed += ReducePlayerHealth;
        pla.Debug.ReduceEnemyHealth.performed += ReduceEnemyHealth;
        pla.Debug.ReduceRadius.performed += ReduceRadius;
        pla.Debug.NextScene.performed += NextScene;
        pla.Debug.PreviousScene.performed += PreviousScene;
        
    }


    private void OnDisable(){
        pla.Disable();
        pla.Debug.IncreaseHealth.performed -= IncreasePlayerHealth;
        pla.Debug.IncreaseEnemyHealth.performed -= IncreaseEnemyHealth;
        pla.Debug.IncreaseRadius.performed -= IncreaseRadius;
        pla.Debug.ReduceHealth.performed -= ReducePlayerHealth;
        pla.Debug.ReduceEnemyHealth.performed -= ReduceEnemyHealth;
        pla.Debug.ReduceRadius.performed -= ReduceRadius;
        pla.Debug.NextScene.performed -= NextScene;
        pla.Debug.PreviousScene.performed -= PreviousScene;

    }
    
    
    private void PauseOnperformed(InputAction.CallbackContext obj){
        
    }


    #region DEBUG INPUT

    public void ReduceRadius(InputAction.CallbackContext context){
        if (context.performed){
            tEL.CheckRadius -= 5f;
        }
    }
    
    public void IncreaseRadius(InputAction.CallbackContext context){
        if (context.performed){
            tEL.CheckRadius += 5f;
        }
    }

    public void NextScene(InputAction.CallbackContext context){
        if (context.performed){
            SceneManager.LoadScene(1);
        }
    }
    
    
    public void PreviousScene(InputAction.CallbackContext context){
        if (context.performed){
            SceneManager.LoadScene(0);
        }    
    }
    

    public void ReduceEnemyHealth(InputAction.CallbackContext context){
        if (context.performed){
            enemy.enemyHealthSystem.ReduceHealth(20);
        }
    }
    
    public void IncreaseEnemyHealth(InputAction.CallbackContext context){
        if (context.performed){
            enemy.enemyHealthSystem.IncreaseHealth(20);
        }
    }

    public void ReducePlayerHealth(InputAction.CallbackContext context){
        if(context.performed){
            player.playerHealthSystem.ReduceHealth(20);
        }
    }
    
    public void IncreasePlayerHealth(InputAction.CallbackContext context){
        if(context.performed){
            player.playerHealthSystem.IncreaseHealth(20);
        }
    }
    #endregion
    
}

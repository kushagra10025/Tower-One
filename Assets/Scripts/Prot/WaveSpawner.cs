using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour{
    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    public SpawnState spawnState = SpawnState.COUNTING;
    public Transform enemySpawnPoint;
    //TODO:For spawn point convert it to array and change the spawnPoint index for each wave
    //by introducing a new field into the WaveClass for SpawnPoint index
    //to make the enemies spawn from different spawn positions.

    public TextMeshProUGUI txtwaveCounter;
    public TextMeshProUGUI txtwaveText;


    private int _nextWave = 0;
    private float _waveCountdown;
    private float _searchCountdown = 1f;

    private void Start(){
        _waveCountdown = timeBetweenWaves;
        txtwaveCounter.text = $"{(_nextWave+1)}/{waves.Length}";
    }

    private void Update(){
        if (spawnState == SpawnState.WAITING){
            //Check if Enemies are still alive
            if (!EnemyIsAlive()){ //all enemies dead or have reached the end goal
                //Begin a new wave
                WaveCompleted();
            }
            else{
                return;
            }
        }
        if (_waveCountdown <= 0f){
            if (spawnState != SpawnState.SPAWNING){
                //Start Spawning Wave
                StartCoroutine(SpawnWave(waves[_nextWave]));
            }
        }
        else{
            _waveCountdown -= Time.deltaTime;
        }
    }

    private void WaveCompleted(){
        Debug.Log("Wave Completed");

        spawnState = SpawnState.COUNTING;
        txtwaveText.text = "prepare for battle...";
        _waveCountdown = timeBetweenWaves;

        if (_nextWave + 1 > waves.Length - 1){
            _nextWave = 0;
            Debug.Log("Completed All Waves");
            Debug.Log("LOOPING");
            //Put GameOver or GameWin Condition here
        }else{
            _nextWave++;
            txtwaveCounter.text = $"{(_nextWave+1)}/{waves.Length}";
        }
    }

    private bool EnemyIsAlive(){
        //Works even when the enemies reach the end of the path.
        //Triggering this function indicating that the enemy is no longer alive
        //TODO:all that needs to be done in that case is the reduce the player health
        //by certain amount for each enemy who has reached the end goal
        _searchCountdown -= Time.deltaTime;
        if (_searchCountdown <= 0f){
            _searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null){
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave t_Wave){
        Debug.Log("Spawning Wave - " +t_Wave.name);
        spawnState = SpawnState.SPAWNING;
        txtwaveText.text = "incoming...";
        for (int i = 0; i < t_Wave.count; i++){
            SpawnEnemy(t_Wave.enemyPrefab);
            yield return new WaitForSeconds(1f/t_Wave.spawnRate);
        }
        spawnState = SpawnState.WAITING;
        txtwaveText.text = "battle to death...";
        //yield break;
    }

    void SpawnEnemy(GameObject t_Enemy){
        //Spawn Enemy
        Debug.Log("Spawning Enemy" + t_Enemy.name);
        Instantiate(t_Enemy, enemySpawnPoint.position, Quaternion.identity);
    }
    
    //SPAWN ENEMIES FUNCTION FROM THE GAME MANAGER
    /*private void SpawnEnemies(){
        for (var index = 0; index < enemySpawns.Length; index++){
            GameObject enemySpawn = enemySpawns[index];
            GameObject go = Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
            go.name = "Enemy " + index;
        }

        enemy = GameObject.FindObjectOfType<EnemyHealth>();
    }*/
}

public enum SpawnState{
    SPAWNING,
    WAITING,
    COUNTING
}

[System.Serializable]
public class Wave{
    public string name;
    public GameObject enemyPrefab;
    public int count;
    public float spawnRate;
}
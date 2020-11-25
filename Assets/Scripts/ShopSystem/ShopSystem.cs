using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopSystem : MonoBehaviour{
    
    private static ShopSystem _instance;
    
    public static ShopSystem Instance{
        get => _instance;
    }

    private int _collectiblesCollected;

    public GameObject shopSystemCanvas;
    [Space]
    
    public GameObject powerUpsButtonsContainer;
    public List<GameObject> powerUpsButtons;
    [Space]

    public TextMeshProUGUI collectibleCountText;

    public int costPerUpgrade = 5;

    public int CollectiblesCollected{
        get => _collectiblesCollected;
        set{
            _collectiblesCollected = value;
            collectibleCountText.text = _collectiblesCollected.ToString("00");
            SpawnCollectibleAtRandomLocation();
        }
    }

    public GameObject collectiblePrefab;
    [Space]
    public Transform[] collectibleSpawnPoint;
    private List<GameObject> btnsInContainer;


    private void Awake(){
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
        
        btnsInContainer = new List<GameObject>();
        
        SpawnCollectibleAtRandomLocation();
    }
    
    private void SpawnCollectibleAtRandomLocation(){
        int randomPointIndex = Random.Range(0, collectibleSpawnPoint.Length);
        GameObject collectible = Instantiate(collectiblePrefab, collectibleSpawnPoint[randomPointIndex].position,
            Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            shopSystemCanvas.SetActive(true);
            GameObject btn1 = Instantiate(powerUpsButtons[Random.Range(0,powerUpsButtons.Count)],powerUpsButtonsContainer.transform);
            GameObject btn2 = Instantiate(powerUpsButtons[Random.Range(0,powerUpsButtons.Count)],powerUpsButtonsContainer.transform);
            GameObject btn3 = Instantiate(powerUpsButtons[Random.Range(0,powerUpsButtons.Count)],powerUpsButtonsContainer.transform);
            btnsInContainer.Add(btn1);
            btnsInContainer.Add(btn2);
            btnsInContainer.Add(btn3);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            Debug.Log("Trigger is being called");
            shopSystemCanvas.SetActive(false);
            GameObject btn1 = btnsInContainer[0];
            GameObject btn2 = btnsInContainer[1];
            GameObject btn3 = btnsInContainer[2];
            btnsInContainer.Clear();
            Destroy(btn1);
            Destroy(btn2);
            Destroy(btn3);
        }
    }
}

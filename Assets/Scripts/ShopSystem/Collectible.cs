using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour{

    private ShopSystem _shopSystem;

    private void Awake(){
        _shopSystem = GameObject.FindObjectOfType<ShopSystem>();
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            _shopSystem.CollectiblesCollected += 1;
            Destroy(gameObject);
        }
    }
}

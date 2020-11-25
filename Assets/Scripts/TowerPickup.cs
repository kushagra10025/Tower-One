using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPickup : MonoBehaviour{
    public Transform destinationTransform;
    public string playerTag="Player";
    public bool hasTowerBeenPicked = false;

    public event EventHandler<bool> OnTowerPicked;

    private Rigidbody _rigidbody;
    private bool isInsideTrigger;
    private TowerEnemyLocator _towerEnemyLocator;
    private Transform _transformParent;
    private PlayerInputActions _playerInputActions;

    public void PickUpDropTower(InputAction.CallbackContext context){
        if (context.performed){
            if (isInsideTrigger){
                if (!hasTowerBeenPicked){
                    _rigidbody.useGravity = false;
                    _transformParent.position = destinationTransform.position;
                    _transformParent.SetParent(destinationTransform.transform);
                    hasTowerBeenPicked = true;
                }
                else{
                    _rigidbody.useGravity = true;
                    _transformParent.parent = null;
                    hasTowerBeenPicked = false;
                }
            }
            OnTowerPicked?.Invoke(this,hasTowerBeenPicked);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other != null && other.CompareTag(playerTag)){
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other != null && other.CompareTag(playerTag)){
            isInsideTrigger = false;
        }
    }

    private void Awake(){
        _transformParent = transform.parent;
        _rigidbody = GetComponentInParent<Rigidbody>();
        _towerEnemyLocator = GetComponentInParent<TowerEnemyLocator>();
        destinationTransform = GameObject.FindGameObjectWithTag("TowerDestination").transform;
        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable(){
        OnTowerPicked += OnOnTowerPicked;
        _playerInputActions.Enable();
        _playerInputActions.Player.PickupDropTower.started += PickUpDropTower;
        _playerInputActions.Player.PickupDropTower.performed += PickUpDropTower;
        _playerInputActions.Player.PickupDropTower.canceled  += PickUpDropTower;
    }
    
    private void OnDisable(){
        OnTowerPicked -= OnOnTowerPicked;
        _playerInputActions.Disable();
        _playerInputActions.Player.PickupDropTower.started -= PickUpDropTower;
        _playerInputActions.Player.PickupDropTower.performed -= PickUpDropTower;
        _playerInputActions.Player.PickupDropTower.canceled  -= PickUpDropTower;
    }

    private void OnOnTowerPicked(object sender, bool e){
        _towerEnemyLocator.enabled = !e;
        _towerEnemyLocator.ClearQueue();
        //TODO:Because Clearing the Queue...so the enemies upon placement of tower change their order
        //Possible : DOnt clear queue.
        //Possible 2 : THINK
    }
}
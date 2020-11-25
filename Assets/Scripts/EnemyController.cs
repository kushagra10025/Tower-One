using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{

    public float movementSpeed = 1f;
    public float rotationSpeed = 120f;
    public float stopDistance = 2.5f;

    [SerializeField] private Vector3 destination;
    [SerializeField] private bool hasReachedDestination;
    
    private CharacterController _characterController;
    private Vector3 velocity;

    public event EventHandler OnReachedDestination;

    private void Update(){
        if (transform.position != destination){
            Vector3 t_destinationDirection = destination - transform.position;
            t_destinationDirection.y = 0;
            float t_destinationDistance = t_destinationDirection.magnitude;

            if (t_destinationDistance >= stopDistance){
                hasReachedDestination = false;
                Quaternion t_targetRotation = Quaternion.LookRotation(t_destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, t_targetRotation,
                    rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }else{
                hasReachedDestination = true;
                OnReachedDestination?.Invoke(this,EventArgs.Empty);
            }
        }
    }

    public void SetHasReachedDestination(bool value){
        hasReachedDestination = value;
    }
    
    public bool GetHasReachedDestination(){
        return hasReachedDestination;
    }

    public void SetDestination(Vector3 destination){
        this.destination = destination;
        hasReachedDestination = false;
    }
}

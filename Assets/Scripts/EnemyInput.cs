using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(EnemyController))]
public class EnemyInput : MonoBehaviour{

    public Waypoint currentWaypoint;
    public bool doesBranch;
    
    private EnemyController _enemyController;

    private int count = 0;

    private void Awake(){
        _enemyController = GetComponent<EnemyController>();

        currentWaypoint = GameObject.FindGameObjectWithTag("InitWaypoint").GetComponent<Waypoint>();
    }

    private void OnEnable(){
        _enemyController.OnReachedDestination += EnemyControllerOnOnReachedDestination;
    }

    private void OnDisable(){
        _enemyController.OnReachedDestination -= EnemyControllerOnOnReachedDestination;
    }

    //This way is efficient because the call for Update Method has been reduced exponentially
    private void EnemyControllerOnOnReachedDestination(object sender, EventArgs e){
        //Debug.Log("Called From " + gameObject.name + "For : " + count + " Times");
        count++;
        if(currentWaypoint.nextWaypoint == null){
            //Dead End Check
            //On Reaching the End Waypoint
            gameObject.SetActive(false);
            _enemyController.SetHasReachedDestination(false);
            return;
        }

        bool t_shouldBranch = false;
        if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0){
            //can manually set whether enemy follows branch
            t_shouldBranch = doesBranch;
            //randomly sets if the enemy follows the branch or not
            //t_shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
        }

        if (t_shouldBranch){
            currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
        }
        else{
            currentWaypoint = currentWaypoint.nextWaypoint;
        }
        
        //On Reaching the next waypoint in path
        _enemyController.SetDestination(currentWaypoint.GetPosition());
    }

    private void Start(){
        _enemyController.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update(){
        
    }
}
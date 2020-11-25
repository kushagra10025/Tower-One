using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour{

    private Transform target;
    private EnemyHealth targetEnemy;

    [Header("General")] 
    public float range = 15f;

    [Header("Use Bullets(default")] 
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("Use Laser")] 
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = 0.5f;

    /**
     * public LineRenderer lineRenderer;
     * public ParticleSystem impactEffect;
     * public Light impactLight;
     */

    [Header("Unity Setup Fields")] 
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform projectileFromPosition;

    private void Start(){
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyHealth>();
        }
        else{
            target = null;
        }
    }

    private void Update(){
        if (target == null){
            /*if (useLaser){
                //check lineRenderer enabled
                    //lineRenderer disables
                    //impactEffect stop
                    //impactlight enables
            }*/
            return;
        }

        LockOnTarget();
        if (useLaser){
            //Laser();
        }
        else{
            if (_fireCountdown <= 0f){
                Shoot();
                _fireCountdown = 1f / fireRate;
            }
            _fireCountdown -= Time.deltaTime;
        }
    }

    private void Shoot(){
        GameObject bulletGO = Instantiate(projectilePrefab, projectileFromPosition.position,
            projectileFromPosition.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null){
            bullet.Seek(target);
        }
    }

    private void LockOnTarget(){
        Vector3 dir = target.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(partToRotate.rotation, lookRot, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rot.y,0f);
    }
    
    void OnDrawGizmos (){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

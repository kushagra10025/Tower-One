using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TowerEnemyLocator : MonoBehaviour{

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public SphereCollider triggerCollider;
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;

    [Header("General")]
    [SerializeField]private float checkRadius = 10f;

    [Header("Use Projectiles")] 
    public GameObject projectilePrefab;
    public float fireRate = 1f;

    [Header("Debug Properties")]
    public EnemyHealth[] currentItemsInQueue;
    
    public float CheckRadius{
        get => checkRadius;
        set{
            checkRadius = value;
            OnCheckRadiusChange?.Invoke(this,value);
        }
    } //To change the sphere radius just change the value of this variable
    
    public event EventHandler<float> OnCheckRadiusChange;
    public event EventHandler OnQueueEnqueued;
    public event EventHandler OnQueueDequeued;

    [SerializeField]private Transform _target;
    private EnemyHealth _targetEnemy;
    private Queue<EnemyHealth> _enemyQueue;
    private float _fireCountdown = 0f;
    private bool _canShoot;

    private void Awake(){
        _enemyQueue = new Queue<EnemyHealth>();
    }

    private void OnEnable(){
        OnCheckRadiusChange += OnOnCheckRadiusChange;
        OnQueueEnqueued += OnOnQueueEnqueued;
        OnQueueDequeued += OnOnQueueDequeued;
    }
    
    private void OnDisable(){
        OnCheckRadiusChange -= OnOnCheckRadiusChange;
        OnQueueEnqueued -= OnOnQueueEnqueued;
        OnQueueDequeued -= OnOnQueueDequeued;
    }

    private void OnOnQueueDequeued(object sender, EventArgs e){
        UpdateTarget();
    }

    private void OnOnQueueEnqueued(object sender, EventArgs e){
        UpdateTarget();
    }

    private void OnOnCheckRadiusChange(object sender, float e){
        triggerCollider.radius = e;
    }

    public void ClearQueue(){
        _enemyQueue.Clear();
        UpdateTarget();
    }

    private void OnTriggerEnter(Collider other){
        if (!other.GetComponent<EnemyHealth>() && !other.CompareTag(enemyTag))
            return;
        
        _enemyQueue.Enqueue(other.GetComponent<EnemyHealth>());
        OnQueueEnqueued?.Invoke(this,EventArgs.Empty);
        //Debug.Log("Sphere Trigger Has been Called");
        
        UpdateTarget();
    }

    private void OnTriggerExit(Collider other){
        if (other.GetComponent<EnemyHealth>() && other.CompareTag(enemyTag)){
            if(_enemyQueue.Count>0)
                _enemyQueue.Dequeue();
            OnQueueDequeued?.Invoke(this,EventArgs.Empty);
        }
    }

    void UpdateTarget(){
        _targetEnemy = _enemyQueue.Count > 0 ? _enemyQueue.Peek() : null;
        _target = _targetEnemy != null ? _targetEnemy.transform : null;
    }

    private void Update(){
        if (_target != null){
            LockOnTarget();
        }
        currentItemsInQueue = _enemyQueue.ToArray(); //Debug Line

        if (_fireCountdown <= 0f){
            Shoot();
            _fireCountdown = 1 / fireRate;
        }
        _fireCountdown -= Time.deltaTime;
    }

    private void Shoot(){
        /*if (!_canShoot)
            return;*/
        //This line causes not shooting action
        GameObject bulletGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null){
            bullet.Seek(_target);
        }

        if (_targetEnemy!= null && _targetEnemy.GetIsDead()){
            if(_enemyQueue.Count > 0)
                _enemyQueue.Dequeue();
            OnQueueDequeued?.Invoke(this,EventArgs.Empty);
        }
    }

    public void SetCanShoot(bool canShoot){
        _canShoot = canShoot;
    }

    private void LockOnTarget(){
        Vector3 t_dir = _target.position - transform.position;
        Quaternion t_lookRot = Quaternion.LookRotation(t_dir);
        Vector3 t_rot = Quaternion.Lerp(partToRotate.rotation, t_lookRot, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,t_rot.y,0f);
    }
}
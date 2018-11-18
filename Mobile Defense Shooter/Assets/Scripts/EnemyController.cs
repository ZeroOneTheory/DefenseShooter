using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {


    public Transform target;
    private NavMeshAgent agent;
    private SegmentController attkTarget;
    public WallManager wallManager;

    // Refactor to Scriptable Object Later 
    public float attackRange=.5f;
    public float attackStrength;
    public float attackFrequency;
    public bool canAttack;
    float attackingRate;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        wallManager = FindObjectOfType<WallManager>();
        target = wallManager.GetNewDestinationTransform();
        agent.SetDestination(target.position);
        attkTarget = target.GetComponent<SegmentController>();

    }

    private void Update() {
        if(agent.remainingDistance <= attackRange) {
            agent.isStopped = true;
            AttackTarget(attkTarget);
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Bullet") {
            GameManager.Instance.LevelManager.AddScore(10, true);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void SetTarget(Transform newTarget) {
        agent.SetDestination(newTarget.position);
    }

    public void AttackTarget(SegmentController target) {
        canAttack = false;
        if (Time.time < attackingRate)
            return;

        attackingRate = Time.time + attackFrequency;
        target.TakeDamage(attackStrength);
        canAttack = true;
    
    }
}

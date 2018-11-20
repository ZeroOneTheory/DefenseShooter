using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    private Transform target;
    private WallManager wallManager;
    private NavMeshAgent agent;
    private SegmentController attkTarget;

    public Enemy enemyTemplate;
    // Refactor to Scriptable Object Later 
    /*
    public float attackRange=.05f;
    public float attackStrength;
    public float attackFrequency; 
    public int scoreForKill;
    */

    private bool canAttack;
    private float attackingRate;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        wallManager = FindObjectOfType<WallManager>();
        target = wallManager.GetNewDestinationTransform();
        agent.SetDestination(target.position);
        gameObject.GetComponentInChildren<MeshFilter>().mesh = enemyTemplate.EnemyModel;
        attkTarget = target.GetComponent<SegmentController>();

    }

    private void Update() {
        if(agent.remainingDistance <= enemyTemplate.attackRange) {
            agent.isStopped = true;
            AttackTarget(attkTarget);
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Bullet") {
            GameManager.Instance.LevelManager.AddScore(enemyTemplate.scoreForKill, true);
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

        attackingRate = Time.time + enemyTemplate.attackFrequency;
        target.TakeDamage(enemyTemplate.attackStrength);
        canAttack = true;
    
    }
}

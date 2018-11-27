using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour {

    public Transform target;
    public Enemy enemyTemplate;
    public float enemyHealth;

    private bool canAttack;
    private float attackingRate;

    private bool canFire;
    private float fireRate;


    private void Awake() {
        enemyHealth = enemyTemplate.maxHealth;
    }

    void Start () {
        gameObject.GetComponentInChildren<MeshFilter>().mesh = enemyTemplate.EnemyModel;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Get Texture template 


    }

    private void Update() {
        // Movement behaviour script
      
    }


    public void ShootAtTarget(Transform target) {
        canFire = false;
        if (Time.time < fireRate)
            return;

        fireRate = Time.time + enemyTemplate.shootFrequency;
        //Shoot towards Player
        canFire = true;
    
    }

    public void MeleeAttack(Transform target) {
        canAttack = false;
        if (Time.time < attackingRate)
            return;

        attackingRate = Time.time + enemyTemplate.attackFrequency;
        //Enforce Player take damage Method
        canAttack = true;

    }

    public void TakeDamage(float dmgAmt) {
        if((enemyHealth-dmgAmt <= 0)) {
            Death();
        }
        enemyHealth -= dmgAmt;
        // Add damage sound effect
        // add impact particle effect
    }

    public void Death() {
        AddScore(enemyTemplate.scoreForKill);
        Destroy(this.gameObject);
        //enemy death particle effect 
        // add enemy death sound effect
    }

    public void AddScore(int score) {
        GameManager.Instance.LevelManager.Score += score;
    }
}

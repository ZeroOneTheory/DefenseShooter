using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentController : MonoBehaviour {

    public float shieldHealth=100;
    public float maxSheildHealth=100;
    public float rechargeRate=5;
    private LevelManager lvlManager;

    private void Start() {
        lvlManager = GameManager.Instance.LevelManager;
    }

    public void Update() {
        RechargeSheild();

        if(shieldHealth <= 0) {
            Dead();
        }
    }

    public void TakeDamage(float dmg) {
        shieldHealth -= dmg;
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        
    }

    public void RechargeSheild() {
        if (shieldHealth < maxSheildHealth) {
            shieldHealth += rechargeRate * Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        } else if (shieldHealth > maxSheildHealth) {
            shieldHealth = maxSheildHealth;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void Dead() {
        lvlManager.RestartLevel();
    }
}

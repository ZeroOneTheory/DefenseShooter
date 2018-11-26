using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float health;

    private LevelManager levelManager;

    public void TakeDamage(float dmgAmt) {
        if ((health <= 0)) {
            Death();
        }
        health -= dmgAmt;
    }

    public void Death() {
        Debug.Log("Doc has died...! ");
    }
}

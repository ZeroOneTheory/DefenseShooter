using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMoveControl : MonoBehaviour {

    public Enemy enemy;
    public Transform tar;
    

    private void Start() { 
        enemy = GetComponentInParent<EnemyController>().enemyTemplate;
        tar = GetComponentInParent<EnemyController>().target;
        

        DecideMovement();
    }

    public void DecideMovement() {
        StartCoroutine(ExecuteMovment(enemy.moveType, tar));
    }

    public IEnumerator ExecuteMovment(AIMoveType moveType, Transform target) {
        switch (moveType) {

            case AIMoveType.towards: 
                        Vector3 direction = target.position - transform.position; 
                        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0f, direction.z));
                        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, enemy.rotationSpeed* Time.deltaTime);
                        transform.Translate(Vector3.forward * enemy.moveSpeed * Time.deltaTime);
                yield return new WaitForSeconds(Random.Range(enemy.idleMinMax.x, enemy.idleMinMax.y));
                break;
               
        }
        yield return null;

    }





}

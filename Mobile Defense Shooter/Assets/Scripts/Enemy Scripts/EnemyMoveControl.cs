using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMoveControl : MonoBehaviour {

    public Enemy enemy;
    public Rigidbody rb;
    public Transform target;

    private Vector3 direction;
    private Quaternion lookRotation;
    private bool canMove=false;
    private float moveRate;


    private void Start() {
        enemy = GetComponentInParent<EnemyController>().enemyTemplate;
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public void Update() {
        direction = target.position - transform.position;
        lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, enemy.rotationSpeed * Time.deltaTime);

        if (!canMove) {
            if (Random.Range(0,3)==1) {
                SetMovement();
                canMove = true;
            }
        }
    }

    public void SetMovement() {
        rb.velocity = Vector3.zero;
        StartCoroutine(ExecuteMove(enemy.moveType));
    }

    public IEnumerator ExecuteMove(AIMoveType moveType) {

        
        if (moveType == AIMoveType.towards) {
            rb.drag = enemy.moveSpeed * .001f;
            rb.AddForce(direction.normalized * enemy.moveSpeed);
        }
        if (moveType == AIMoveType.inchTowrads) {
            rb.drag = enemy.moveSpeed*.001f*9f;
            rb.AddForce(direction.normalized * enemy.moveSpeed);
            yield return new WaitForSeconds(enemy.idleMinMax.y);
        }
        yield return null;
        SetMovement();
    }


}

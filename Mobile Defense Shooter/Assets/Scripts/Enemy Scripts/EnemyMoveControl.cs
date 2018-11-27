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
        if(moveType == AIMoveType.sineTowrads) {
            // Ehhh this is not working correctly
            /* Example from Sebastian --------------------
             * 
             * Vector3 target = targetPosition + targetDirectionFromPlayer *.7 + Vector3.up * .5f;
             * transform.position = Vector3.SmoothDamp(transform.position,target,ref smoothV, speed);
             * 
             * float XOffset = Mathf.Sin(Time.time*random.xSpeed);
             * float YOffset = (Mathf.Sin(Time.time*random.ySpeed )+1 * random.yDegree;
             * Vector3 offset = new Vector3(offsetX,offsetY) * (1.1f-offsetPercent);
             * Transform.Translate(deltaOffset,Space.self);
             * 
             */
            rb.drag = enemy.moveSpeed * .001f;
            float sine = Mathf.Sin(Time.time * Random.Range(1, 5)) * transform.position.z;
            Vector3 sineDir = new Vector3(direction.x + sine, direction.y, direction.z + sine);
            rb.AddForce(sineDir * enemy.moveSpeed);
        }
        yield return null;
        SetMovement();
    }


}

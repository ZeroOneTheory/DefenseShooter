using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    public float rotationSpeed;
    public Transform target;
    InputController inputController;


	// Use this for initialization
	void Start () {
        inputController = GameManager.Instance.InputController;
	}
	
	// Update is called once per frame
	void Update () {

        if (inputController.isDragging) {
            RotatePlayer(target);
        }

    }

    public void RotatePlayer(Transform lookTarget) {
        Vector3 direction = lookTarget.position - transform.position; 
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0f, direction.z));
        Debug.Log(lookRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime *rotationSpeed);
    }
    
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    public float rotationSpeed;
    public Transform target;
    public InputController inputController;
    


	// Use this for initialization
	void Awake () {
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
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed* Time.deltaTime);
    }
    
}

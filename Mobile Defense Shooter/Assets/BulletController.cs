using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletSpeed=10;

	// Use this for initialization
	void Awake () {
        Destroy(this, 5);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;

    }
}

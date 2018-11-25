using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public Bullet bullet;

	// Use this for initialization
	void Awake () {

        gameObject.tag = bullet.type.ToString();
        Destroy(this.gameObject,3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * bullet.bulletSpeed * Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "playerBullet") {
           // Damage Enemy & Check for killshot
        }

        if (other.gameObject.tag == "player" && this.gameObject.tag == "Enemy") {
            // Damage player & check for killshot
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public Weapon defaultWeapon;
    public Weapon equipped;

    public bool canFire;
    public float weaponFireRate;
    float firingRate;

    public GameObject weaponBulletPrefab;

    public Transform cannonLeft;
    public Transform cannonRight;
    bool toggleLeftRightCannon=true;
    Transform releasePoint;

    InputController input;


    // Use this for initialization
    void Start () {
        input = GameManager.Instance.InputController;
        if (equipped == null) { EquipWeapon(defaultWeapon); }
	}
	
	// Update is called once per frame
	void Update () {

        if (input.isDragging) { Fire(); }
	}
    public void EquipWeapon(Weapon equip) {
        equipped = equip;
        weaponFireRate = equip.fireRate;
        weaponBulletPrefab = equip.bullet.transform.gameObject;

    }

    public void Fire() {

        canFire = false;
        if (Time.time < firingRate)
            return;

        if(toggleLeftRightCannon == true){ releasePoint = cannonLeft; }else{ releasePoint = cannonRight; }
        toggleLeftRightCannon = !toggleLeftRightCannon;

        firingRate = Time.time + weaponFireRate;
        Instantiate(weaponBulletPrefab, releasePoint.position, releasePoint.rotation);
        canFire = true;
    }
}

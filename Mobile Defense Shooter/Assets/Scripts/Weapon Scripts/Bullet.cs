using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Bullet",menuName ="Armory/Bullets")]
public class Bullet : ScriptableObject {

    public enum BulletType { Enemy, playerBullet}
    public BulletType type;

    [SerializeField]
    public GameObject bulletPrefab;
    public float damageAmount;
    public float bulletSpeed;


}

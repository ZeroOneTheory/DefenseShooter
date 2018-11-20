using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Armory/Weapons")]
public class Weapon : ScriptableObject {
    public string Name;
    public float fireRate;
    public int clipSize;
    public Transform bullet;
}

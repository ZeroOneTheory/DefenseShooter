using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIMoveType {
    towards = 0,
    idle = 1,
    rotateLeft = 2,
    rotateRight = 3,
    sineTowrads = 4,
    inchTowrads = 5

}

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject {

    public string EnemyName;
    public Mesh EnemyModel;
    public Texture EnemyUV;
    public float maxHealth;

    public AIMoveType moveType;
    public float moveSpeed;
    public float rotationSpeed;
    public Vector2 idleMinMax;
    public float attackRange = .05f;
    public float attackStrength;
    public float attackFrequency;

    [SerializeField]
    public GameObject BulletPrefab;
    public float shootFrequency;

    public int scoreForKill;



}

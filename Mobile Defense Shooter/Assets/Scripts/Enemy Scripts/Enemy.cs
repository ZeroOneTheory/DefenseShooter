using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject {

    public string EnemyName;
    public Mesh EnemyModel;
    public Texture EnemyUV;
    public float attackRange = .05f;
    public float attackStrength;
    public float attackFrequency;
    public int scoreForKill;


}

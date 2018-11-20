using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemies = new GameObject[2];
    public Transform[] spawnPositions = new Transform[4];
    public float spawnWait;
    public Vector2 spawnWaitMinMax = new Vector2(5, 50);
    public int startWait;

    public bool isSpawning = true;
    public int chooseEnemy;
    public int choosePosition;

    private void Start() {
        StartCoroutine(Spawner());
    }

    private void Update() {
       // spawnWait = Random.Range(spawnWaitMinMax.x, spawnWaitMinMax.y);
        //spawnWait = 1;
    }


    IEnumerator Spawner() {

        yield return new WaitForSeconds(startWait);

        while (isSpawning) {
            chooseEnemy = 0; // decides which enemy to spawn
            choosePosition = Random.Range(0, spawnPositions.Length - 1);
            Instantiate(enemies[chooseEnemy], spawnPositions[choosePosition]);
            yield return new WaitForSeconds(spawnWait);

        }
    }
    void DecreaseSpawnRate() {

    }
}

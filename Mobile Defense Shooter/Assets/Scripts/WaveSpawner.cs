using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState {  spawning,waiting,counting}


    [System.Serializable]
    public class Wave {

        public string waveName;
        public float spawnRate;
        public Unit[] enemys;

        [System.Serializable]
        public class Unit {
            public string groupName;
            public GameObject enemy;
            public Transform spawnPoint;
            public int unitCount;
        }
    }

    public Wave[] waves;
    private int nextWave = 0;

    private SpawnState spawnState = SpawnState.counting; 
    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    public void Start() {

        waveCountDown = timeBetweenWaves;
    }

    private void Update() {

        if (waveCountDown <= 0) {
            if(spawnState != SpawnState.spawning) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else {
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave wave) {

        spawnState = SpawnState.spawning;
        
        for(int i=0; i<waves.Length-1; i++) {
            
        }

        spawnState = SpawnState.waiting;
        yield break;
    }

    


}

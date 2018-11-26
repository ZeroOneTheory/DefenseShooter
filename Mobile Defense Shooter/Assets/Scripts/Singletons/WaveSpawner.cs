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

    public SpawnState spawnState = SpawnState.counting;
    public float waveCountDown;
    public float spawnSpread = 8;
    public float timeBetweenWaves = 5f;
    public Wave[] waves;


    private int nextWave = 0;

    public void Start() {

        waveCountDown = timeBetweenWaves;
    }

    private void Update() {

        if (waveCountDown <= 0) {
            if(spawnState != SpawnState.spawning) {
                waveCountDown = 0;
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else {
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave wave) {

        spawnState = SpawnState.spawning;
        
        for(int a=0; a<waves.Length; a++) { // loop through each wave

            for(int b=0; b<waves[a].enemys.Length; b++) { // loop through the enemys in each wave
                
                for(int c=0; c<waves[a].enemys[b].unitCount; c++) // repeat the number of times based on the unit count 
                { 
                    Debug.Log("Spawning " + waves[a].enemys[b].groupName);
                    Vector3 spawnPoint = new Vector3(waves[a].enemys[b].spawnPoint.position.x+Random.Range(1, spawnSpread), 1f, waves[a].enemys[b].spawnPoint.position.z + Random.Range(1, spawnSpread));
                    Instantiate(waves[a].enemys[b].enemy,spawnPoint,Quaternion.identity);
                    yield return new WaitForSeconds(1f / wave.spawnRate);
                }
                Debug.Log("Spawning " + waves[a].waveName);
            }
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        spawnState = SpawnState.waiting;
        waveCountDown = timeBetweenWaves;
        yield break;
    }

    


}

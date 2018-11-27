using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public bool gameLost = false;
    public int Score;
    public int killCount;
    public float dropFrequency;
    private Scene currentScene;

    private void Awake() {
        DontDestroyOnLoad(this);
    }

    public void Start() {
        currentScene = SceneManager.GetActiveScene();
    }

    public void AddScore(int score) {
        Score += score; 
    }

    public void AddScore(int score,bool incrKillCnt) {
        Score += score;
        if (incrKillCnt) { IncrKillCount(); }
    }

    public void IncrKillCount() {
        killCount += 1;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(currentScene.name);
    }

}

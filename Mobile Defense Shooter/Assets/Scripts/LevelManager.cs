using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public bool gameLost = false;
    public int Score;
    public int killCount;

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

}

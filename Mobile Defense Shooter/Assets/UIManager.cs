using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;

    private LevelManager levelManager;

    private void Start() {
       levelManager = GameManager.Instance.LevelManager;
       scoreText = GetComponentInChildren<Text>();
    }

    private void LateUpdate() {
        scoreText.text = levelManager.Score.ToString();
    }

}

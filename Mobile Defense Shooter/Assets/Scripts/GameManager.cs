using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager {

    

    private GameObject gameObject;
    private static GameManager m_Instance;
    public static GameManager Instance {
        get {
            if (m_Instance == null) {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputController>();
                m_Instance.gameObject.AddComponent<LevelManager>();
                m_Instance.gameObject.AddComponent<DifficultyController>();
                
            }
            return m_Instance;
        }
    }


    private InputController m_InputController;
    public InputController InputController {
        get {
            if (m_InputController == null && gameObject != null) {
                m_InputController = gameObject.GetComponent<InputController>();
            }
            return m_InputController;
        }
    }

    private LevelManager m_levelManager;
    public LevelManager LevelManager {
        get {
            if (m_levelManager == null && gameObject != null) {
                m_levelManager = gameObject.GetComponent<LevelManager>();
            }
            return m_levelManager;
        }
    }

    private DifficultyController m_difficultyController;
    public DifficultyController DifficultyController {
        get {
            if (m_difficultyController == null && gameObject != null) {
                m_difficultyController = gameObject.GetComponent<DifficultyController>();
            }
            return m_difficultyController;
        }
    }






}

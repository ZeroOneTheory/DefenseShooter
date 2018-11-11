using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour {

    private GameObject gameObject;
    private static GameManager m_Instance;
    public static GameManager Instance {
        get {
            if(m_Instance == null) {
                m_Instance = new GameManager {
                    gameObject = new GameObject("_gameManager")
                };
                
                // Add components to Game manager using m_instance.gameObject.AddComponent<DESIRED COMPONENT>();

            }
            return m_Instance;
        }
    }




}

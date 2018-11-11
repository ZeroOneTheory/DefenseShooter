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
                m_Instance.gameObject.AddComponent<InputController>();
                // Add components to Game manager using m_instance.gameObject.AddComponent<DESIRED COMPONENT>();

            }
            return m_Instance;
        }
    }

    private static InputController m_InputController;
    public static InputController InputController {
        get{
            if(m_InputController == null) {
                m_InputController= m_Instance.gameObject.GetComponent<InputController>();
            }
            return m_InputController;
        }
        
    }


}

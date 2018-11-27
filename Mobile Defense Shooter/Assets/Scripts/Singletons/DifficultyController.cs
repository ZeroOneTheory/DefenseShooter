using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour {

    private int m_diffMode=0;
    public int difficultyMode { get { return m_diffMode; } }

    private float m_speedMulti = 0;
    public float speedMultiplyer { get { return m_speedMulti+m_diffMode; } }

    private float m_attackMulti = 0;
    public float attackMulti { get { return m_attackMulti+ m_diffMode; } }

    private float m_spawnRateMulti = 0;
    public float SpawnRateMultiplyer { get { return m_spawnRateMulti+ m_diffMode; } }

    public float timeClock;
    public float timeOffset=.001f;

    private void Update() {
        timeClock = Time.time* timeOffset;
    }


}

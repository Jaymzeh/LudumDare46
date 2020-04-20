using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public int score = 0;
    float multiplier = 0f;

    public Dispenser[] disp;
    public Dispenser coilDisp;

    void Start() {
        GameEvents.CURRENT.onHoopTriggerEnter += OnHoopEnter;
    }

    void OnHoopEnter() {
        score++;
    }

}
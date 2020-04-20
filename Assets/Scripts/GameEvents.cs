using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    public static GameEvents CURRENT;

    void Awake() {
        CURRENT = this;
    }


    public event Action onHoopTriggerEnter;
    public void HoopTriggerEnter() {
        if (onHoopTriggerEnter!= null)
            onHoopTriggerEnter();
    }
}

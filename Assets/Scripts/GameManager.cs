using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public int score = 0;
    int counter = 0;
    int threshold = 4;
    float multiplier = 0f;

    public Dispenser[] disp;
    public Dispenser coilDisp;
    int hoopsActive = 0;

    public Text scoreText;
    public Text thresholdText;

    

    void Start() {
        GameEvents.CURRENT.onHoopTriggerEnter += OnHoopEnter;
        scoreText.text = "SCORE: " + score;
        thresholdText.text = "POINTS UNTIL COIL: " + (threshold-counter);
    }

    void OnHoopEnter() {
        score++;
        counter++;

        CheckCounter();

        scoreText.text = "SCORE: " + score;
        thresholdText.text = "POINTS UNTIL COIL: " + (threshold-counter);

        

        if (hoopsActive <= 0)
            ResetHoops();

    }

    void CheckCounter() {
        if (counter >= threshold) {
            counter = 0;
            threshold += 2;
            coilDisp.Activate(true);
            ResetHoops();
        }
    }

    void ResetHoops() {

        for (int i = 0; i < disp.Length; i++) {
            if (disp[i].active)
                continue;
            if (Random.Range(0, 2) == 0) {
                disp[i].Activate(true, Random.Range(30, 75));
                hoopsActive++;
            }
        }

    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }

}
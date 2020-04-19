using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public int numOfCoils = 5;

    static bool[] coilsActive;
    public static bool[] CoilsActive {
        get { return coilsActive; }
    }

    public List<Coil> coils;
    public static List<Coil> Coils {
        get { return Instance.coils; }
    }

   
    

    void Awake() {
        Instance = this;
    }

    void Start() {
        coilsActive = new bool[numOfCoils];
    }

    void UpdateCoils() {

        //Randonly choose which coils to activate
        for (int i = 0; i < numOfCoils; i++) {
            if (Random.Range(1, 3) == 1) {
                coilsActive[i] = true;
            }
            else
                coilsActive[i] = false;
        }
    }

    void Update() {


    }
}
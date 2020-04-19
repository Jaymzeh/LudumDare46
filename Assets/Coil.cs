using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : MonoBehaviour {

    public GameObject idleLightning;
    public GameObject lightningTrail;

    public GameObject drone;

    void Start() {
        lightningTrail.SetActive(false);
    }

    void Update() {
        if (lightningTrail.active) {
            lightningTrail.transform.LookAt(drone.transform.position);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Drone")) {
            idleLightning.SetActive(false);
            lightningTrail.SetActive(true);
            drone = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Drone")) {
            idleLightning.SetActive(true);
            lightningTrail.SetActive(false);
            drone = null;
        }
    }
}
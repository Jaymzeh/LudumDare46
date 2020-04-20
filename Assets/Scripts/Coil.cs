using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : MonoBehaviour {

    public GameObject idleLightning;
    public GameObject lightningTrail;
    public float chargeLeft = 20;

    public GameObject drone;

    void Start() {
        lightningTrail.SetActive(false);
    }

    void FixedUpdate() {
        if (lightningTrail.active) {
            lightningTrail.transform.LookAt(drone.transform.position);
        }
        if (chargeLeft <= 0)
            lightningTrail.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {

        if (chargeLeft <= 0)
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Drone")) {
            idleLightning.SetActive(false);
            lightningTrail.SetActive(true);
            drone = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other) {
        if (chargeLeft <= 0)
            return;
        if (other.gameObject.layer == LayerMask.NameToLayer("Drone")) {
            idleLightning.SetActive(true);
            lightningTrail.SetActive(false);
            drone = null;
        }
    }

}
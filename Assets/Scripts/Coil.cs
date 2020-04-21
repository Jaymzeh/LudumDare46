using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : Tower {

    public GameObject idleLightning;
    public GameObject lightningTrail;
    public float chargeLeft = 20;

    public GameObject drone;
    AudioSource audioSource;


    void Start() {
        lightningTrail.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        if (lightningTrail.active) {
            lightningTrail.transform.LookAt(drone.transform.position);
            audioSource.Play();
        }
        if (chargeLeft <= 0) {
            audioSource.Stop();
            lightningTrail.SetActive(false);
            dispenser.Activate(false);
            this.enabled = false;
        }
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Drone")) {
            idleLightning.SetActive(true);
            lightningTrail.SetActive(false);
            drone = null;
        }
    }

}
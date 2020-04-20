using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCharge : MonoBehaviour {

    public Coil coil;
    public float chargeAmount = 1;

    public ParticleSystem particleStream;
    List<ParticleCollisionEvent> collisionEvents;

    void Start() {
        particleStream = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other) {

        int numCollisionEvents = particleStream.GetCollisionEvents(other, collisionEvents);

        if (other.gameObject.layer == LayerMask.NameToLayer("Drone")) {
            other.GetComponent<DroneController>().power += chargeAmount;
            Debug.Log("Charging...");
        }

        DroneController target = other.GetComponent<DroneController>();
        int i = 0;

        while (i < numCollisionEvents) {
            if (target) {
                target.power += chargeAmount;
                coil.chargeLeft--;
            }
            i++;
        }
    }
}
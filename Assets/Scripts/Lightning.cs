using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
    ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    void Start() {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other) {

        Debug.Log("Particle hit");

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : Tower {

    bool active = true;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Drone")) {
            active = false;
            dispenser.Activate(false);
        }
    }

}
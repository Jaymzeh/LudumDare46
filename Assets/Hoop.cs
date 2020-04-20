using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : Tower {

    bool active = true;

    void OnTriggerEnter(Collider other) {

        if (!active)
            return;

        if(other.gameObject.layer == LayerMask.NameToLayer("Drone")) {

            GameEvents.CURRENT.HoopTriggerEnter();

            active = false;
            dispenser.Activate(false);
        }
    }

}
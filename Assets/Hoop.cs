using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : Tower {

    void OnTriggerExit(Collider other) {

        if(other.gameObject.layer == LayerMask.NameToLayer("Drone")) {

            GameEvents.CURRENT.HoopTriggerEnter();
            dispenser.Activate(false);
            this.enabled = false;
        }
    }

}
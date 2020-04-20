//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour {

//    public float forwardSpeed = 30;
//    float vertical;
//    float horizontal;
//    public float turnSpeed = 5;
//    public float climbSpeed = 20;
//    public float selfRightingTorque = 150;
//    public float power = 100;
//    public float powerLossRate;

//    public float health = 100;

//    public GameObject target;

//     public enum State {
//        Seeking,    //looking for enemy
//        Attacking,  //duh
//        LowPower,   //looking for power
//        Powering    //using power source
//    }
//    public State currentState = State.Seeking;

//    struct Priorities {
//        public float seek;
//        public float attack;
//        public float findPower;
//    }
//    Priorities priority;

//    void Start() {

//    }

    

//    void OnTriggerEnter(Collider other) {

//    }
//    void OnTriggerExit(Collider other) {
//        if (other.gameObject.Equals(target)) {
//            priority.attack = 0;
//            priority.seek = 10;
//        }
//    }

//    void FindClosestCoil() {
//        float closestDist = 0;
//        int closest = 0;
//        for (int i = 0; i < GameManager.Coils.Count; i++) {
//            float dist = Vector3.Distance(transform.position, GameManager.Coils[i].transform.position);
//            if( dist <= closestDist) {
//                closestDist = dist;
//                closest = i;
//            }
//        }

//        target = GameManager.Coils[closest].gameObject;

//    }

//    void MoveTowardsTarget() {
//        if (target == null)
//            return;
//    }

//    void Seek() {
//        Vector3 dir = target.transform.position - transform.position;
//        Ray ray = new Ray(transform.position, dir);
//        RaycastHit hit;

//        if(Physics.Raycast(ray,out hit)) {
//            if (hit.collider.gameObject.Equals(target)) {
                
//            }
//        }

//    }

//    void Update() {

//        switch (currentState) {
//            case State.Seeking:
//            Seek();
//            break;
//            case State.LowPower:

//            break;
//        }

//        if (power <= 50) {
//            priority.findPower = 10;
//            priority.seek = 2;
//            priority.attack = 0;
//        }


//        if (health <= 0)
//            Destroy(gameObject);

//    }
//}
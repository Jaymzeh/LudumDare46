using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float forwardSpeed = 10f;

    public float forwardTilt = 0f;
    public float sideTilt = 0f;
    public float turnSpeed = 10;


    Transform model;
    Animator anim;

    public float rotorBaseSpeed = 10;


    void Awake() {
        model = transform.GetChild(0);
        anim = GetComponent<Animator>();
    }

    void GetInput() {

        if (Input.GetAxis("Vertical") != 0) {
            transform.Translate(-Vector3.forward * Input.GetAxis("Vertical"), Space.Self);
        }

        if (Input.GetAxis("Horizontal") != 0) {
            transform.Translate(-Vector3.right * Input.GetAxis("Horizontal"), Space.Self);
        }

        if (Input.GetAxis("Turn") > 0) {
            transform.Rotate(0, turnSpeed, 0);
        }
        if (Input.GetAxis("Turn") < 0) {
            transform.Rotate(0, -turnSpeed, 0);
        }

    }

    public void Update() {

        GetInput();
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));


    }
}

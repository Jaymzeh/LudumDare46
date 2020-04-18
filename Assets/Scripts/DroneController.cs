using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float forwardSpeed = 10f;

    public float forwardTilt = 0f;
    public float sideTilt = 0f;

    float remainingPower = 100;

    Transform model;

    void Awake() {
        model = transform.GetChild(0);
    }

    void GetInput() {

        if (Input.GetAxis("Vertical") == 0) {
            forwardTilt = Mathf.Lerp(forwardTilt, 0, Time.deltaTime * 1f);
        }
        else {
            forwardTilt = Input.GetAxis("Vertical") * -40;

            if (forwardTilt > 0)
                transform.Translate(Vector3.forward * forwardSpeed, Space.Self);
            else
                transform.Translate(Vector3.forward * -forwardSpeed, Space.Self);
        }

        if (Input.GetAxis("Horizontal") == 0) {
            sideTilt = Mathf.Lerp(0, sideTilt, Time.deltaTime * 1f);
        }
        else {
            sideTilt = Input.GetAxis("Horizontal") * 40;

            if (sideTilt > 0)
                transform.Translate(Vector3.right * -forwardSpeed/2, Space.Self);
            else
                transform.Translate(Vector3.right * forwardSpeed/2, Space.Self);
        }
    }

    public void Update() {

        GetInput();

        model.rotation = Quaternion.RotateTowards(model.rotation,
            Quaternion.Euler(forwardTilt, 0, sideTilt), 5);

    }
}

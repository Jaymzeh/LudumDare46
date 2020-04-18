using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float forwardSpeed = 10f;

    public float forwardTilt = 0f;
    public float sideTilt = 0f;


    void GetInput() {

        if (Input.GetAxis("Vertical") == 0) {
            forwardTilt = Mathf.Lerp(forwardTilt, 0, Time.deltaTime * 0.5f);
        }
        else
            forwardTilt = Input.GetAxis("Vertical")*-40;
        //    if (Input.GetAxis("Vertical") > 0) {
        //    forwardTilt = Mathf.Lerp(forwardTilt, -45, Time.deltaTime * 1);
        //}
        //else
        //    if (Input.GetAxis("Vertical") < 0) {
        //    forwardTilt = Mathf.Lerp(forwardTilt, 45, Time.deltaTime * 1);
        //}

        if (Input.GetAxis("Horizontal") == 0) {
            sideTilt = Mathf.Lerp(0, sideTilt, Time.deltaTime * 0.5f);
        }
        else
            sideTilt = Input.GetAxis("Horizontal")*40;
    }

    public void Update() {

        GetInput();

        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.Euler(forwardTilt, 0, sideTilt), 1);

    }
}

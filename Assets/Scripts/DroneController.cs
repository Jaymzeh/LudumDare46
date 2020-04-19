using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float forwardSpeed = 10f;

    public float vertical = 0f;
    public float horizontal = 0f;
    public float turnSpeed = 10;
    public float climbSpeed = 5f;
    public float selfRightingTorque = 100f;

    Vector4 input = new Vector4();

    Animator anim;
    Rigidbody rigidbody;


    void Awake() {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void GetInput() {

        input = new Vector4(
            Input.GetAxis("Horizontal"),    //x
            Input.GetAxis("Climb"),         //y
            Input.GetAxis("Vertical"),      //z
            Input.GetAxis("Turn"));         //w

        if (input.z != 0) { //forward movement
            rigidbody.AddForce(Mathf.Round(input.z) * (-transform.forward) * forwardSpeed, ForceMode.Acceleration);
        }

        if (input.x != 0) { //Side strafe
            rigidbody.AddTorque(transform.up * (Mathf.Round(input.x) * turnSpeed), 
                ForceMode.Impulse);
        }

        if (input.y > 0) {  //climb
            rigidbody.AddForce(Vector3.up * climbSpeed, ForceMode.Acceleration);
        }
        if (input.y < 0) {  //climb
            rigidbody.AddForce(Vector3.down * (climbSpeed*2), ForceMode.Acceleration);
        }
    }

    void FixedUpdate() {

        //Self Balancing
        float angle = Vector3.Angle(transform.up, Vector3.up);
        if(angle > 0.01) {

            Vector3 axis = Vector3.Cross(transform.up, Vector3.up);
            rigidbody.AddTorque(axis * angle * selfRightingTorque);
            Debug.Log("Self righting...");
        }
    }

    public void Update() {

        GetInput();
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        anim.SetFloat("Vertical", vertical);
        anim.SetFloat("Horizontal", horizontal);
    }

}

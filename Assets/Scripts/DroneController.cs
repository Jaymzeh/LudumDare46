using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public float power = 100f;
    public float powerLossRate = 10f;
    float elapsedTime = 0f;

    public Slider powerSlider;
    public Image powerWarning;

    AudioSource audioSource;
    public float maxPitch = 1.5f;
    public float minPitch = 0.75f;

    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    void Awake() {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate() {

        input = new Vector4(
            Input.GetAxis("Horizontal"),    //x
            Input.GetAxis("Climb"),         //y
            Input.GetAxis("Vertical"),      //z
            Input.GetAxis("Turn"));         //w


        if (input.y > 0) {  //climb
            rigidbody.AddForce(Vector3.up * climbSpeed, ForceMode.Acceleration);
            audioSource.pitch = 1.34f;
        }
        else if (input.y < 0) {  //fall
            rigidbody.AddForce(Vector3.down * (climbSpeed * 2), ForceMode.Acceleration);
            audioSource.pitch = 0.75f;
        }

        if (input.z != 0) { //forward movement
            rigidbody.AddForce(Mathf.Round(input.z) * (-transform.forward) * forwardSpeed, ForceMode.Acceleration);

            audioSource.pitch += (input.z * 0.5f);

        }

        if (input.x != 0) { //Side strafe
            rigidbody.AddTorque(transform.up * (Mathf.Round(input.x * 2) * turnSpeed),
                ForceMode.Impulse);
        }




        audioSource.pitch = Mathf.Clamp(audioSource.pitch, minPitch, maxPitch);
 
        //Self Balancing
        float angle = Vector3.Angle(transform.up, Vector3.up);
        if(angle > 0.01) {

            Vector3 axis = Vector3.Cross(transform.up, Vector3.up);
            rigidbody.AddTorque(axis * angle * selfRightingTorque);
            Debug.Log("Self righting...");
        }

        if (powerSlider != null)
            powerSlider.value = power / 100;
    }

    public void Update() {

        anim.SetFloat("Power", power);

        if (power > 0) {

            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
            anim.SetFloat("Vertical", vertical);
            anim.SetFloat("Horizontal", horizontal);
        }
        else {
            vertical = 0;
            horizontal = 0;
        }
        

        if (powerLossRate != 0) {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= 1) {
                power -= powerLossRate;
                elapsedTime = 0;

                if (powerWarning != null)
                    if (power <= 25)
                        powerWarning.enabled = !powerWarning.enabled;
                    else
                        powerWarning.enabled = false;
            }

            if (power <= 0) {
                rigidbody.useGravity = true;
                rigidbody.mass = 200;
                rigidbody.drag = 0;
                rigidbody.angularDrag = 0;
                anim.SetFloat("Power", 0);
                audioSource.Stop();
                gameOverScreen.SetActive(true);
                this.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (!pauseScreen.active) {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
            else {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }

            
        }

    }

}

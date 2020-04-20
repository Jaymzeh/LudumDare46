using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour {

    Animator anim;
    public Transform towerParent;
    public GameObject[] towerPrefabs;
    public GameObject activeTower;
    public float towerHeight = 50;
    public float raiseSpeed = 5;
    public bool active;
    public bool close;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void Activate(bool isActive) {
        active = isActive;

        anim.SetBool("Open", active);
        StartCoroutine("RaiseTower", active);
    }

    IEnumerator RaiseTower(bool raise) {

        float targetHeight = 0;

        if (raise) {
            targetHeight = transform.position.y;

            activeTower = Instantiate(towerPrefabs[0], 
                towerParent.position,   //match position
                towerParent.rotation,   //match rotation
                towerParent);           //set tower parent

            while(towerParent.position.y < targetHeight) {
                towerParent.Translate(transform.up * (raiseSpeed*Time.deltaTime), Space.Self);
                yield return null;
            }

        }
        else {
            targetHeight = transform.position.y - towerHeight;

            while(towerParent.position.y > targetHeight) {
                towerParent.Translate(-transform.up * (raiseSpeed*Time.deltaTime), Space.Self);
                yield return null;
            }
            Destroy(activeTower);
        }
    }

    // Update is called once per frame
    void Update() {

        if (active) {
            Activate(true);
            active = false;
        }

        if (close) {
            Activate(false);
            close = false;
        }

    }
}

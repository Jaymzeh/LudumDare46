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
        anim = GetComponentInChildren<Animator>();
    }

    public void Activate(bool isActive) {
        active = isActive;

        if (active)
            anim.SetBool("Open", true);

        StartCoroutine("RaiseTower", active);
    }
    public void Activate(bool isActive, float newHeight) {
        towerHeight = newHeight;
        Activate(isActive);
    }

    IEnumerator RaiseTower(bool raise) {

        float targetHeight = 0;

        

        if (raise) {
            targetHeight = transform.position.y + towerHeight;

            if (towerParent.childCount != 0)
                Destroy(towerParent.GetChild(0).gameObject);

            activeTower = Instantiate(towerPrefabs[0], 
                towerParent.position,   //match position
                towerParent.rotation,   //match rotation
                towerParent);           //set tower parent
            activeTower.GetComponent<Tower>().Dispenser = this;

            while(towerParent.position.y < targetHeight) {
                towerParent.Translate(Vector3.up * (raiseSpeed*Time.deltaTime), Space.World);
                yield return null;
            }

        }
        else {
            targetHeight = transform.position.y;

            while(towerParent.position.y > targetHeight) {
                towerParent.Translate(-Vector3.up * (raiseSpeed*Time.deltaTime), Space.World);
                yield return null;
            }
            anim.SetBool("Open", false);
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

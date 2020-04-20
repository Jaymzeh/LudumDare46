using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public Dispenser dispenser;

    public Dispenser Dispenser {
        get { return dispenser; }
        set { dispenser = value; }
    }
}

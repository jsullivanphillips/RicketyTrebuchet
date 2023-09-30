using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{

    [SerializeField] GameObject orb;

    public GameObject Orb { //constructor
        get { return this.orb; }
        set { this.orb= value; }
    }

    public void DropOrb() {
        // Instantiate(this.orb, this.transform.position);
    }
}

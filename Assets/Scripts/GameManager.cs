using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plop this guy 

public class GameManager : MonoBehaviour
{
    //[SerializeField] GameObject droppedOrb; // probably don't need a full thing
    // [SerializeField] private float pickupSpeed;
    
    [SerializeField] GameObject player;


    public static GameManager instance { get; private set;}

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than one Game Manager in the scene.");
        }
        instance = this;
    }


}

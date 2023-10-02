using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject droppedOrb;
    [SerializeField] private float pickupSpeed;
    [SerializeField] GameObject player;
    [SerializeField] Player_Controller_test playerScript;
  

    void Start()
    {
        if(AudioManager.Singleton != null)
        {
            AudioManager.Singleton.Play("Ambience");
            AudioManager.Singleton.Play("SpookySong");
        }
        
    }
}

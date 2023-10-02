using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    [SerializeField] GameObject droppedOrb;
    [SerializeField] private float pickupSpeed;
    [SerializeField] GameObject player;
    [SerializeField] Player_Controller_test playerScript;

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

        void Start()
    {
        if(AudioManager.Singleton != null)
        {
            AudioManager.Singleton.Play("Ambience");
            AudioManager.Singleton.Play("SpookySong");
        }
        
    }
}

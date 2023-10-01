using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{

    [SerializeField] Rigidbody2D player;
    [SerializeField] private float pickupSpeed;
    private bool playerInOrbRange = false;

    void Start()
    {
        Debug.Log("Orb is here");
        // assign player rigidbody2d to orb
        // Animation / particles
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            playerInOrbRange = true;
        }
    }

    void Update()
    {
        if (playerInOrbRange) {
            if (transform.position != player.transform.position) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, pickupSpeed * Time.deltaTime);
            } else {
                // give player orb and play animation
                Destroy(gameObject);
            }
        }    
        
        
    }
}

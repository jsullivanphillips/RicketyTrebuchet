using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{

    [SerializeField] Rigidbody2D player;
    [SerializeField] private float pickupSpeed;

    void Start()
    {
        Debug.Log("Orb is here");
        // Animation / particles
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Player") {
            while (transform.position != player.transform.position) {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, pickupSpeed * Time.deltaTime); // instantly teleports when it should slowly move
                // give player orb and play animation
            }
            //Destroy(gameObject);
        }
        
    }

    void Update()
    {
        // maybe check if in range of player so it can delete and update player, but that will probably be on player's end
    }
}

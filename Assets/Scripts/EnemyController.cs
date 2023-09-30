using System.Collections;
using System.Collections.Generic;
// using System.Numerics; //do I need this? other controllers don't have it and it makes new Vector2 throw an error
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] PlayerDummyController player; // will work later, grants access to isPlayerInBubble
    [SerializeField] private int enemyHealth;
    [SerializeField] private int attackDamage;
    [SerializeField] private float enemySpeed = 1.0f;
    [SerializeField] private float enemyRange = 1.0f;
    [SerializeField] private float enemyAttackDelay = 2.5f;
    [SerializeField] GameObject dummyOrb;
    private float timePassed = 0f; // for attack delay

    void IsPlayerInBubble() {
        if (player.playerInBubble && ! IsEnemyInRange()) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        }
    }

    bool IsEnemyInRange() {
        float distanceBetweenEnemyAndPlayer = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if (distanceBetweenEnemyAndPlayer <= enemyRange) { // is player in range of enemy
            if (player.playerHealth > 0) {
                EnemyAttack();
            }
            return true;
        } else {
            return false;
        }
    }

    void EnemyAttack() {
        timePassed += Time.deltaTime;
        if (timePassed > enemyAttackDelay) {
            // play animation
            Debug.Log("hit!");
            player.playerHealth -= 1;
            timePassed = 0f;
        }
    }

    void OnDeath() { // how do I properly instantiate orb at postion of enemy
        // Instantiate(dummyOrb);
        // dummyOrb.transform = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Destroy(gameObject);
    }

    // private void OnTriggerEnter2D(Collider2D other) { //COULD: animation for enemy trying to smash bubble
    //     if (other.tag == "bubble") {
    //         //play animation
    //     }
    // }

    void Start() {

    }

    void Update() {
        IsPlayerInBubble();

        if (Input.GetKeyDown(KeyCode.LeftShift)) { // just to test dying
            OnDeath();
        }
    }
}


// health - ability to be hit by player
// if player is not in bubble, give velocity in direction of player DONE
// if within range of player, swing and deal damage DONE (need animation though)
// Could: animation if enemy is touching bubble DONE (again need animation)
// onDeath - drop orb and delete prefab
// spawn function
// 
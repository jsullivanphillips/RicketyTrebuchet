using System.Collections;
using System.Collections.Generic;
// using System.Numerics; //do I need this? other controllers don't have it and it makes new Vector2 throw an error
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] PlayerDummyController PlayerDummyControllerComp; // will work later, grants access to isPlayerInBubble
    [SerializeField] GameObject Player; // will work later, grants access to isPlayerInBubble
    [SerializeField] private int enemyHealth;
    [SerializeField] private int attackDamage;
    [SerializeField] private float enemySpeed = 1.0f;
    [SerializeField] private float enemyRange = 1.0f;
    [SerializeField] private float enemyAttackDelay = 2.5f;
    // [SerializeField] GameObject orb;
    private float timePassed = 0f; // for attack delay
    [SerializeField] private int distanceThreshold;
    private float playerEnemyDistance;

    private void Start()
    {
        PlayerDummyControllerComp = Player.GetComponent<PlayerDummyController>();
    }

    void IsPlayerInBubble() {
        if (PlayerDummyControllerComp.playerInBubble && ! IsEnemyInRange() && playerEnemyDistance < distanceThreshold) {
            transform.position = Vector2.MoveTowards(transform.position, PlayerDummyControllerComp.transform.position, enemySpeed * Time.deltaTime);
        }
    }

    bool IsEnemyInRange() {
        float distanceBetweenEnemyAndPlayer = Vector2.Distance(gameObject.transform.position, PlayerDummyControllerComp.transform.position);
        if (distanceBetweenEnemyAndPlayer <= enemyRange) { // is player in range of enemy
            if (PlayerDummyControllerComp.playerHealth > 0) {
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
            // plays animation
            Debug.Log("hit!");
            PlayerDummyControllerComp.playerHealth -= 1;
            timePassed = 0f;
        }
    }

    void OnDeath() { // spawns "orb" at enemy then deletes enemy
        // Instantiate(orb, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); ADD LATER: drops orb which can be picked up by player
        //PlayerDummyControllerComp.playerOrbs -= 1;
        // plays animation
        Destroy(gameObject);
    }

    // private void OnTriggerEnter2D(Collider2D other) { //COULD: animation for enemy trying to smash bubble
    //     if (other.tag == "bubble") {
    //         // plays animation
    //     }
    // }



    void Update() {
        IsPlayerInBubble(); // calls IsPlayerInRange, which calls EnemyAttack

        playerEnemyDistance = Vector2.Distance(gameObject.transform.position, Player.transform.position);

        if (enemyHealth <= 0) {
            OnDeath();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) { // just to test dying
            OnDeath();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
// using System.Numerics; // do I need this? other controllers don't have it and it makes new Vector2 throw an error
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

// TODO: List of functions Brendan need to implement: playerIsInBubble(), getCurrentHealth(), hurtPlayer(), addCrystal()

public class EnemyController : MonoBehaviour
{

    // [SerializeField] PlayerDummyController PlayerDummyControllerComp;
    [SerializeField] private int enemyHealth;
    [SerializeField] private int attackDamage; // not using
    [SerializeField] private float enemySpeed = 1.0f;
    [SerializeField] private float enemyRange = 1.0f;
    [SerializeField] private float enemyAttackDelay = 2.5f;
    // [SerializeField] GameObject orb;
    private float timePassed = 0f; // for attack delay
    [SerializeField] private int distanceThreshold;
    private float playerEnemyDistance;
    private Transform Player;

    private void Start()
    {
        Player = GameObject.Find("Player Controller").transform;
    }

    void IsPlayerInBubble() {
        if (GameManager.instance.playerIsInBubble() && ! IsEnemyInRange() && playerEnemyDistance < distanceThreshold) { // wait for brendan
            transform.position = Vector2.MoveTowards(transform.position, Player.position, enemySpeed * Time.deltaTime);
        }
    }

    bool IsEnemyInRange() {
        float distanceBetweenEnemyAndPlayer = Vector2.Distance(gameObject.transform.position, Player.position);
        if (distanceBetweenEnemyAndPlayer <= enemyRange) { // is player in range of enemy
            if (GameManager.instance.getCurrentHealth() > 0) { // wait for brendan
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
            GameManager.instance.hurtPlayer(); // wait for brendan
            timePassed = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.tag == "Projectile") {
            enemyHealth -= 1;
        }
    }

    void OnDeath() { // spawns "orb" at enemy then deletes enemy
        // Instantiate(orb, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); ADD LATER: drops orb which can be picked up by player
        GameManager.instance.addCrystal();// wait for brendan
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

        playerEnemyDistance = Vector2.Distance(gameObject.transform.position, Player.position);

        if (enemyHealth <= 0) {
            OnDeath();
        }
        
        // if (Input.GetKeyDown(KeyCode.LeftShift)) { // just to test dying
        //     OnDeath();
        // }
    }
}


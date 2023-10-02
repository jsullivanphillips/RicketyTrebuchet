using System.Collections;
using System.Collections.Generic;
// using System.Numerics; // do I need this? other controllers don't have it and it makes new Vector2 throw an error
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

// TODO: List of functions Brendan need to implement: playerIsInBubble()

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
    [SerializeField] private int attackDamage; // not using
    [SerializeField] private float enemySpeed = 1.0f;
    [SerializeField] private float enemyRange = 1.0f;
    [SerializeField] private float enemyAttackDelay = 1f;
    [SerializeField] private float enemyStrollFrequency = 3f; // how often the enemy walks around (in seconds) while player in bubble
    // [SerializeField] GameObject orb;
    private float timePassed = 0f; // for attack delay
    [SerializeField] private int distanceThreshold;
    private float playerEnemyDistance;
    private Transform Player;
    
    [SerializeField] private bool facingRight;

    private void Start()
    {
        //Player = GameObject.Find("Player");
        //PlayerDummyControllerComp = Player.GetComponent<PlayerDummyController>();
        Player = GameObject.Find("Player Controller").transform;
    }

    void IsPlayerInBubble() {
        if (GameManager.instance.playerIsInBubble() && ! IsEnemyInRange()) { // wait for brendan
            if (playerEnemyDistance < distanceThreshold) {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, enemySpeed * Time.deltaTime);
            } else {
                // DoAFunnyLittleDance();
            }
        }  
    }

    bool IsEnemyInRange() {
        float distanceBetweenEnemyAndPlayer = Vector2.Distance(gameObject.transform.position, Player.position);
        if (distanceBetweenEnemyAndPlayer <= enemyRange) { // is player in range of enemy
            if (GameManager.instance.getCurrentHealth() > 0) {
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
            GameManager.instance.hurtPlayer();
            GameManager.instance.hurtPlayer();
            timePassed = 0f;
        }
    }

    // private void DoAFunnyLittleDance() { // makes the enemy stroll around a radius when player is in bubble
    //     timePassed += Time.deltaTime;
    //     if (timePassed > enemyStrollFrequency) {
    //         Vector2 enemyPos = new Vector2(transform.position.x, transform.position.y);
    //         Vector2 randomPoint = new Vector2(Random.insideUnitCircle * 5);
    //         while (enemyPos != randomPoint) {
    //             transform.position = Vector2.MoveTowards(enemyPos, randomPoint, enemySpeed * Time.deltaTime); // MAYBE WORKS IDK
    //         }
    //         timePassed = 0f;
    //     }
        
    // }

    void OnDeath() { // spawns "orb" at enemy then deletes enemy
        // Instantiate(orb, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); ADD LATER: drops orb which can be picked up by player
        GameManager.instance.addOrb();
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
        
        Vector3 difference = Player.position - transform.position;

        if (difference.x >= 0 && !facingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(1, 1, 1); // or activate look right some other way
            facingRight = true;
        }
        if (difference.x < 0 && facingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(-1, 1, 1); // activate looking left
            facingRight = false;
        }

    }

    private void OnTriggerStay2D(Collider2D Object)
    {
        if (Object.gameObject.name == "Sparkle Blast")
        {
            enemyHealth -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("hit");
            enemyHealth -= 1;
        }
    }
}
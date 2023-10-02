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
    [SerializeField] private float enemyAttackDelay = 1f;
    // [SerializeField] GameObject orb;
    private float timePassed = 0f; // for attack delay
    [SerializeField] private int distanceThreshold;
    private float playerEnemyDistance;
    [SerializeField] private bool facingRight;

    private void Start()
    {
        Player = GameObject.Find("Player");
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
            if (Player.GetComponent<Player_Controller_test>().PlayerHealth > 0) {
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
            Player.GetComponent<Player_Controller_test>().PlayerHealth -= 1;
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

        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        Vector3 difference = Player.transform.position - transform.position;

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


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] PlayerDummyController player; // will work later, grants access to isPlayerInBubble
    [SerializeField] private int EnemyHealth;
    [SerializeField] private int AttackDamage;
    [SerializeField] private int EnemySpeed;

    private Rigidbody2D enemyRigidBody2D;

    // Start is called before the first frame update

    void Awake() {
        enemyRigidBody2D = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        
    }

    void Start() {
        player = GameObject.FindObjectOfType<PlayerDummyController>(); // init player
    }

    // Update is called once per frame
    void Update() {
        
    }
}


// health
// if player is in bubble, give velocity in direction of player
// if within range of player, swing and deal damage
// Could: animation if enemy is touching bubble
// 
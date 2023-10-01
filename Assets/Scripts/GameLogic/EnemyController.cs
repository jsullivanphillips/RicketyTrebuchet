using System.Collections;
using System.Collections.Generic;
// using System.Numerics; //do I need this? other controllers don't have it and it makes new Vector2 throw an error
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] PlayerDummyController player; // will work later, grants access to isPlayerInBubble
    [SerializeField] private int EnemyHealth;
    [SerializeField] private int AttackDamage;
    [SerializeField] private float EnemySpeed;

    void Start() {
    }

    void Update() {
        if (player.playerInBubble) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, EnemySpeed * Time.deltaTime);
        }
    }
}


// health - ability to be hit by player
// if player is not in bubble, give velocity in direction of player DONE
// if within range of player, swing and deal damage
// Could: animation if enemy is touching bubble
// onDeath - drop orb and delete prefab
// spawn function
// 
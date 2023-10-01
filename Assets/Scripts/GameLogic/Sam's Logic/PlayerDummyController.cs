using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummyController : MonoBehaviour
{

    [SerializeField] EnemyController enemy;
    [SerializeField] private Rigidbody2D dummyPlayer;
    [SerializeField] public int playerHealth = 3;
    public bool playerInBubble; // this maybe shouldn't be public i'm not sure
    private bool playerIsDead = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerInBubble = ! playerInBubble;
        }

        if (playerHealth <= 0 && !playerIsDead) {
            playerIsDead = true;
            Debug.Log("ded lol");
        }
        
    }
}

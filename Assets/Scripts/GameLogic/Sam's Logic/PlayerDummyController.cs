using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummyController : MonoBehaviour
{

    [SerializeField] EnemyController enemy;
    [SerializeField] private Rigidbody2D dummyPlayer;
    [SerializeField] public int playerHealth = 3;
    [SerializeField] public float dummyPlayerSpeed = 5;
    [SerializeField] public int playerOrbs = 3;

    public bool playerInBubble; // this maybe shouldn't be public i'm not sure
    private bool playerIsDead = false;
    private float moveHorizontal = 0;
    private float moveVertical = 0;

    void Start()
    {
        
    }

    void Update()
    {

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) {
            playerInBubble = ! playerInBubble;
        }

        if (playerHealth <= 0 && !playerIsDead) {
            playerIsDead = true;
            Debug.Log("ded lol");
        }

        if (moveHorizontal != 0) {
            dummyPlayer.velocity = new Vector2(dummyPlayerSpeed * moveHorizontal, dummyPlayer.velocity.y);
        }

        if (moveVertical != 0) {
            dummyPlayer.velocity = new Vector2(dummyPlayer.velocity.x, dummyPlayerSpeed * moveVertical);
        }
        
    }
}

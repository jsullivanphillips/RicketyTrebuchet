using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private Rigidbody2D player;
    private float moveHorizontal = 0;
    private float moveVertical = 0;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        velocity = player.velocity;
    }

    private void FixedUpdate() {
        if (moveHorizontal != 0) {
            player.velocity = new Vector2(moveSpeed * moveHorizontal, player.velocity.y);
        }

        if (moveVertical != 0) {
            player.velocity = new Vector2(player.velocity.x, moveSpeed * moveVertical);
        }

        /*if (player.velocity.x <= 0.05f) {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (player.velocity.y <= 0.05f) {
            player.velocity = new Vector2(player.velocity.x, 0);
        }*/

    }
}

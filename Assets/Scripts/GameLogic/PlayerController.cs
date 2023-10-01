using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Config")]
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private Rigidbody2D player;
    private float moveHorizontal = 0;
    private float moveVertical = 0;

    [Header("Wand Config")]
    [SerializeField] private Transform wandOrbit;
    [SerializeField] private Transform wand;
    [SerializeField] private float wandDist;

    [Header("Blaster Config")]
    [SerializeField] private CrosshairController crosshair;
    [SerializeField] private GameObject sparkleBlast;
    [SerializeField] private float blast_distance;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0)) {
            GameObject new_blast = Instantiate(sparkleBlast, wand.position, wandOrbit.rotation);
        }

        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("right");
        }
    }

    private void FixedUpdate() {
        if (moveHorizontal != 0) {
            player.velocity = new Vector2(moveSpeed * moveHorizontal, player.velocity.y);
        }

        if (moveVertical != 0) {
            player.velocity = new Vector2(player.velocity.x, moveSpeed * moveVertical);
        }

        //TODO: add lag to roation for natural feel (lerp? slerp? quaternion rotation???)
        wandOrbit.right = crosshair.transform.position - wandOrbit.position;
    }
}

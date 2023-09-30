using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummyController : MonoBehaviour
{

    [SerializeField] EnemyController enemy;
    [SerializeField] private Rigidbody2D dummyPlayer;
    public bool playerInBubble; // this maybe shouldn't be public i'm not sure

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerInBubble = ! playerInBubble;
        }
        
    }
}

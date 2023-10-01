using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_test : MonoBehaviour
{
    public float MovementSpeed = 5.0f; // 2D Movement speed to have independant axis speed
    [SerializeField] private new Rigidbody2D rigidbody2D; // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    private Vector2 inputVector;
    [SerializeField] public bool facingRight;
    public int Chrystal_spawn_count = 3;
    public float Cooldown_timer_Crystal = 0;
    public float Cooldown_timer_limit_Crystal = 5;
    public bool Can_spawn_Crystal = false;
    [SerializeField] private GameObject Crystal_Prefab;
    [SerializeField] private float Player_size;

    void Start()
    {
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {

        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        if (Cooldown_timer_Crystal < Cooldown_timer_limit_Crystal && Can_spawn_Crystal == false)
        {
            Cooldown_timer_Crystal += Time.deltaTime;
        }
        else
        {
            Can_spawn_Crystal = true;
        }

        if (Input.GetMouseButtonDown(0) && Chrystal_spawn_count > 0 && Can_spawn_Crystal == true)
        {
            Chrystal_spawn_count -= 1;
            Cooldown_timer_Crystal = 0;
            Can_spawn_Crystal = false;
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // zero z
            Instantiate(Crystal_Prefab, mouseWorldPos, Quaternion.identity);

        }

        if (difference.x >= 0 && !facingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(Player_size, Player_size, 1); // or activate look right some other way
            facingRight = true;
        }
        if (difference.x < 0 && facingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(-Player_size, Player_size, 1); // activate looking left
            facingRight = false;
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }
}

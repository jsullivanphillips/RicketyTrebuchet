using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand_Script : MonoBehaviour
{
    [SerializeField] private bool facingRight;
    [SerializeField] private GameObject Player;


    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Player.GetComponent<Player_Controller_test>().facingRight == true)
        { // mouse is on right side of player
            transform.localScale = new Vector3(1, 1, 1); // or activate look right some other way
        }
        else
        { // mouse is on left side
            transform.localScale = new Vector3(-1, 1, 1); // activate looking left
        }
    }
}


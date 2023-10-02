using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_script : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float IncreaseSpead = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player Controller");
    }

    private void OnTriggerStay2D(Collider2D Object)
    {
        if (Object.gameObject == Player && Player.GetComponent<Player_Controller_test>().WandPower < 10 && Input.GetKey(KeyCode.E))
        {
            Player.GetComponent<Player_Controller_test>().WandPower += IncreaseSpead * Time.deltaTime;
            GetComponentInParent<Chrystal_BH>().ShrinkSpeedIncrease = 2.5f;
        }
        else 
        {
            GetComponentInParent<Chrystal_BH>().ShrinkSpeedIncrease = 1f;
        }
    }


}
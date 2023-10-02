using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCrystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Crystal") {
            SceneLoader.Singleton.LoadScene("EndCredits");
        }
    }
}

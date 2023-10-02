using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Singleton.Play("MainMenu");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.Singleton.FadeInSong("MainMenu");
    }

    public void OnStartBtn()
    {
        AudioManager.Singleton.FadeOutSong("MainMenu");
        SceneLoader.Singleton.LoadScene("isaiahScene");
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.Singleton.FadeInSong("MainTheme");
    }

    public void OnStartBtn()
    {
        AudioManager.Singleton.FadeOutSong("MainTheme");
        SceneLoader.Singleton.LoadScene("ProductionScene");
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }
}

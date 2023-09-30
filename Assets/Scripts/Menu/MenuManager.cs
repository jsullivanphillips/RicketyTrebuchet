using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void OnStartBtn()
    {
        SceneLoader.Singleton.LoadScene("PlayerScene");
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }
}

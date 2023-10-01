using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public void OnButtonClick()
    {
        AudioManager.Singleton.Play("ButtonClick");
    }
}

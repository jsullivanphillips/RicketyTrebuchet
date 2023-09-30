using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Singleton { get; private set; }
    [SerializeField] Animator _animator;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (Singleton != null && Singleton != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Singleton = this;
        }
        _animator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        _animator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        _animator.SetTrigger("FadeOut");
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneHelper(sceneName));
    }

    IEnumerator LoadSceneHelper(string sceneName)
    {
        _animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }


}

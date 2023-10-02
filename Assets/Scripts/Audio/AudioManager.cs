using Unity.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [Range(0, 1)]
    public float volume;
    public bool isMusicEnabled = true;
    public bool isSoundEnabled = true;
    private List<Sound> music = new List<Sound>();
    public List<string> songs = new List<string>();

    bool setupDone = false;

    public static AudioManager Singleton;

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (!setupDone)
            Setup();
    }


    void Setup()
    {
        DontDestroyOnLoad(this.gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume * volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if (s.isMusic)
            {
                music.Add(s);
            }
        }
        setupDone = true;
    }

    bool MusicIsPlaying()
    {
        foreach (Sound s in music)
        {
            if (s.source.isPlaying) return true;
        }
        return false;
    }


    public void StopAllMusic()
    {
        foreach (Sound s in music)
        {
            if (s.source.isPlaying) FadeOutSong(s);
        }
    }

    public void FadeOutSong(Sound s)
    {
        StartCoroutine(FadeOut(s));
    }

    public void FadeOutSong(string s)
    {
        StartCoroutine(FadeOut(sounds[IndexOfSong(s)]));
    }

    int IndexOfSong(string s)
    {
        int i = 0;
        foreach (Sound sound in sounds)
        {
            if (sound.name == s) return i;
            i++;
        }
        return -1;
    }


    IEnumerator FadeOut(Sound s)
    {
        var originalVolume = s.source.volume;
        while (s.source.volume > 0.1)
        {
            s.source.volume -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
        s.source.Stop();
        s.source.volume = originalVolume;
    }


    public void FadeInSong(string s)
    {
        StartCoroutine(FadeIn(sounds[IndexOfSong(s)]));
    }

    IEnumerator FadeIn(Sound s)
    {

        var originalVolume = s.source.volume;
        s.source.volume = 0f;
        s.source.Play();
        while (s.source.volume < originalVolume)
        {
            s.source.volume += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
        s.source.volume = originalVolume;

    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        if (s.isMusic && (!isMusicEnabled || MusicIsPlaying()))
        {
            return;
        }
        else if (isSoundEnabled)
        {
            s.source.Play();
        }
    }

    public void DisableMusic()
    {
        isMusicEnabled = false;
        PauseAll();
    }

    public void EnableMusic()
    {
        isMusicEnabled = true;
        ResumeAll();
    }


    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void PauseAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Pause();
        }
    }

    public void PauseSong(string name)
    {
        sounds[IndexOfSong(name)].source.Pause();
    }

    public void ResumeSong(string name)
    {
        sounds[IndexOfSong(name)].source.UnPause();
    }

    public void ResumeAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.UnPause();
        }
    }
}

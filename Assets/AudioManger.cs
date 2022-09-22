using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManger instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }
    public void play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        s.source.Play();
        if (s == null)
        {
            return;

        }
    }
}
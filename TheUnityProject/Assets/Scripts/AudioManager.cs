using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public Sounds[] sounds;

    private void Awake()
    {
        instance = this;

       foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.source.volume;
            s.source.loop = s.source.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            print("NO SOUNDS");
            return;
        }
        s.source.Play();
    }
}

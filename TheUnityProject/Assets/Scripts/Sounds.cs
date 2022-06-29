using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;

    public AudioClip clip;

    [Range(0, 1)]
    public float volume;

    public bool canLoop;

   [HideInInspector] public AudioSource source;
}

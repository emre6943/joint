using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Audio
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    public bool playOnAwake = false;

    public AudioMixerGroup audioMixerGroup;

    [System.NonSerialized]
    public AudioSource source;
}
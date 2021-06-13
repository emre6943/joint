using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [HideInInspector]
    public static AudioManager instance = default;

    public Audio[] audios;

    [HideInInspector] public string currentTheme;

    private void Awake()
    {
        if (instance == null) instance = this;

        foreach (Audio s in audios)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            // s.source.outputAudioMixerGroup = s.audioMixerGroup;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        // foreach (Audio audio in audios)
        // {
        //     if (audio.playOnAwake)
        //     {
        //         PlaySound(audio.name);
        //     }
        // }
        currentTheme = audios[UnityEngine.Random.Range(0, 6)].name;
        PlaySound(currentTheme);
    }

    public void PlaySound(string name)
    {
        Audio s = Array.Find(audios, sound => sound.name == name);
        if (s == null) Debug.LogError("Cannot find the sound with name: " + name);
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Audio s = Array.Find(audios, sound => sound.name == name);
        if (s == null) Debug.LogError("Cannot find the sound with name: " + name);
        s.source.Stop();
    }
}
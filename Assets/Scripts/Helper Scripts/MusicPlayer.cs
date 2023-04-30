using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class MusicPlayer : SingletonMB<MusicPlayer>
{    
    private AudioSource _music;
    private float _musicVolume = .1f;

    private void Awake()
    {
        _music = gameObject.AddComponent<AudioSource>();
        _music.loop = true;
        
    }

    // this music player is specialized to play 2 audio clips at once
    public void PlayNewSong(AudioClip newSong, float volume)
    {
        if (newSong == null) return;    // guard clause

        if (newSong != null)
        {
            _music.clip = newSong;
            _music.volume = volume;
            _music.Play();
        }
        
    }


    private void Update()
    {
        _music.volume = _musicVolume;
    }

    public void UpdateMusicVolume(float volume)
    {
        _musicVolume = volume;
    }
}

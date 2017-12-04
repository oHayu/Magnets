using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public List<AudioClip> pewPews, booms;
    public AudioSource pewPlayer, boomPlayer;
    public static SoundManager instance = null;


    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    
    public void PlayBoom(int index) {
        boomPlayer.PlayOneShot(booms[index]);
    }


    public  void playPew(int index) {
        pewPlayer.PlayOneShot(pewPews[index]);
    }
}

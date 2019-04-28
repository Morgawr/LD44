using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44 {
public class SoundPlayer : MonoBehaviour {

    float LastHitPlayed;
    public AudioSource Hit;
    public AudioSource Loss;
    public AudioSource Victory;

    public void Awake() {
        LastHitPlayed =  Time.timeSinceLevelLoad;
        Hit.volume = 0;
        Loss.volume = 0;
        Victory.volume = 0;
    }

    public void PlayHit() {
        if(!Hit.isPlaying && (Time.timeSinceLevelLoad - LastHitPlayed > 1)) {
            Hit.Play();
            LastHitPlayed = Time.timeSinceLevelLoad;
        }
    }

    public void PlayLoss() {
        Loss.Play();
    }

    public void PlayVictory() {
        Victory.Play();
    }

    public void TurnOff() {
        Hit.volume = 0;
        Loss.volume = 0;
        Victory.volume = 0;
    }

    public void TurnOn() {
        Hit.volume = 1;
        Loss.volume = 1;
        Victory.volume = 1;
    }
}
}
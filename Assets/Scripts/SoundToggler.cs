using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class SoundToggler : MonoBehaviour {
    private bool soundEnabled = false;

    public Image EnabledSprite;
    public Image DisabledSprite;

    public SoundPlayer FXPlayer;
    public AudioSource IdleAudio;

    public void Toggle() {
        if(soundEnabled) {
            EnabledSprite.gameObject.SetActive(false);
            DisabledSprite.gameObject.SetActive(true);
            IdleAudio.volume = 0;
            FXPlayer.TurnOff();
        } else {
            EnabledSprite.gameObject.SetActive(true);
            DisabledSprite.gameObject.SetActive(false);
            IdleAudio.volume = 1;
            FXPlayer.TurnOn();
        }
        soundEnabled = !soundEnabled;
    }
}
}
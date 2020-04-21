using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class adfloaujhsygfdsaoiudyfhopsaie : MonoBehaviour
{
    public AudioMixer mixer;

    public void StartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void SetMusicVolume(float musicLvl) {
        mixer.SetFloat("Music", musicLvl);
    }

    public void SetSFXVolume(float sfxLvl) {
        mixer.SetFloat("SFX", sfxLvl);
    }

}

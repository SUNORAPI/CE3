using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    public TextMeshProUGUI PauseBT;
    bool playing;
    float Length;
    public static float SliderValue;
    private void Start()
    {
        Length = audioSource.clip.length;
    }

    public void MusicStart()
    {
        audioSource.Play();
        playing = true;
    }
    public void MusicStop() 
    {
        audioSource.Stop();
        playing = false;
    }
    public void MusicPause() 
    {
        if (playing)
        {
            audioSource.Pause();
            playing = false;
            PauseBT.text = ">";
        }
        else if (!playing)
        {
            audioSource.UnPause();
            playing = true;
            PauseBT.text = "ll";
        }
    }

    private void Update()
    {
        slider.value = audioSource.time / Length;
        SliderValue = slider.value;
    }

    public void sliderchanged()
    {
        audioSource.time = Length * slider.value;
    }
}

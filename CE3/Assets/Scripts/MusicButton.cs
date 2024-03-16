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
    public static float NowMusicTime;
    public static int BposX;
    public static int BposY;
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
    public void StepP1()
    {
        audioSource.time += ChartCalculator.TPL;
    }
    public void StepP5()
    {
        audioSource.time += 5 * ChartCalculator.TPL;
    }
    public void StepM1()
    {
        audioSource.time -= ChartCalculator.TPL;
    }
    public void StepM5()
    {
        audioSource.time -= 5 * ChartCalculator.TPL;
    }
    public void NotesBX(int BX) 
    {
        BposX = BX; 
    }
    public void NotesBY(int BY)
    {
        BposY = BY;
    }

    private void Update()
    {
        NowMusicTime = audioSource.time;
        slider.value = audioSource.time / Length;
        SliderValue = slider.value;
    }

    public void sliderchanged()
    {
        audioSource.time = Length * slider.value;
    }
}

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
    [SerializeField]public GameObject K;
    LineSCR L;
    private int _BX;
    private int _BY;
    private void Start()
    {
        Length = audioSource.clip.length;
        L=K.GetComponent<LineSCR>();
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
    public void NBX(int X)
    {
        _BX = X;
    }
    public void NBY(int Y)
    {
        _BY = Y;
    }
    public void NotesBV2() 
    {
        Vector2 BV2 = new Vector2(_BX,_BY);
        L.AddN(BV2);
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

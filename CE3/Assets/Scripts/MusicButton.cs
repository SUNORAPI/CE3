using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] public GameObject M1;
    [SerializeField] public GameObject M5;
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
    public static int NNUM;
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
        if (NNUM >= 1)
        {
            audioSource.time -= ChartCalculator.TPL;
        }
    }
    public void StepM5()
    {
        if (NNUM >= 5)
        {
            audioSource.time -= 5 * ChartCalculator.TPL;
        }
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
        L.NoteButton(_BX, _BY);
    }

    private void Update()
    {
        NowMusicTime = audioSource.time;
        slider.value = audioSource.time / Length;
        SliderValue = slider.value;
        if (NNUM >= 1) 
        {
            M1.SetActive(true);
            if (NNUM >= 5)
            {
                M5.SetActive(true);
            }
            else
            {
                M5.SetActive(false);
            }
        }
        else
        {
            M1.SetActive(false);
            M5.SetActive(false);
        }
    }

    public void sliderchanged()
    {
        audioSource.time = Length * slider.value;
    }

    public void NoteMode(int m)
    {
        LineSCR.Notesmode = m;// 0:lower 1:upper
        L.Notemodechange(m);
    }
}

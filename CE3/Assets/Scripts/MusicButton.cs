using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] public GameObject M1;
    [SerializeField] public GameObject M5;
    [SerializeField] public GameObject Lwbtn;
    [SerializeField] public GameObject Upbtn;
    [SerializeField] public GameObject Wdp1btn;
    [SerializeField] public GameObject Wdm1btn;
    [SerializeField] public GameObject WdT;
    [SerializeField] public GameObject NowWidthT;
    TextMeshProUGUI nwt;
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
    string[] Colorstr = new string[] { "#00BFFF", "#FF1493" };
    private void Start()
    {
        nwt = NowWidthT.GetComponent<TextMeshProUGUI>();
        Length = audioSource.clip.length;
        L=K.GetComponent<LineSCR>();
    }

    private void Update()
    {
        Color Btc;
        UnityEngine.ColorUtility.TryParseHtmlString(Colorstr[LineSCR.Notesmode], out Btc);
        if (LineSCR.Notesmode == 0)
        {
            Button Lb = Lwbtn.GetComponent<Button>();
            Button Ub = Upbtn.GetComponent<Button>();
            Lb.image.color = Btc;
            Ub.image.color = Color.white;
        }
        else if(LineSCR.Notesmode == 1)
        {
            Button Lb = Lwbtn.GetComponent<Button>();
            Button Ub = Upbtn.GetComponent<Button>();
            Lb.image.color = Color.white;
            Ub.image.color = Btc;
        }
        else 
        {
            Button Lb = Lwbtn.GetComponent<Button>();
            Button Ub = Upbtn.GetComponent<Button>();
            Lb.image.color = Color.white;
            Ub.image.color = Color.white;
        }
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
        if(LineSCR.Noteslength < LineSCR.mlen && LineSCR.Noteslength > 1 && LineSCR.Isselecting)
        {
            Wdp1btn.SetActive(true);
            Wdm1btn.SetActive(true);
        }
        else if(LineSCR.Noteslength >= LineSCR.mlen && LineSCR.Isselecting)
        {
            Wdp1btn.SetActive(false);
            Wdm1btn.SetActive(true) ;
        }
        else if(LineSCR.Noteslength <= 1 && LineSCR.Isselecting)
        {
            Wdp1btn.SetActive(true);
            Wdm1btn.SetActive(false);
        }
        else
        {
            Wdp1btn.SetActive(false);
            Wdm1btn.SetActive(false);
            WdT.SetActive(false);
            NowWidthT.SetActive(false);
        }
        nwt.text = LineSCR.Noteslength.ToString();
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

    public void sliderchanged()
    {
        audioSource.time = Length * slider.value;
    }

    public void NoteMode(int m)
    {
        LineSCR.Notesmode = m;// 0:lower 1:upper
        L.Notemodechange(m);
    }
    public void NoteWidth(int w)
    {
        LineSCR.Noteslength += w;
        L.Notewidthchange(w);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetInput : MonoBehaviour
{
    public TMP_InputField PathI;//曲のパス
    public TMP_InputField BPMI;//Beat per minute
    public TMP_InputField BeatPerMeasureI;//1小節あたりの拍数
    public TMP_InputField LevelI;
    public TMP_InputField ComposerI;
    public TMP_InputField ChartMakerI;
    public TMP_InputField MusicTimeI;//曲の始めから終わりまでの時間
    public TMP_InputField LPBI;

    public TextMeshProUGUI PathText;
    public TextMeshProUGUI BPMText;
    public TextMeshProUGUI BeatPerMeasureText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI ComposerText;
    public TextMeshProUGUI ChartMakerText;
    public TextMeshProUGUI MusicTimeText;
    public TextMeshProUGUI LPBText;

    public static string Path = "C:/Users/hoday/Downloads/168_HammerGirl.mp3";
    public static float BPM = 168.0f;
    public static int BeatPerMeasure = 4;
    public static int Level = 1;
    public static string Composer = "SUNORAPI";
    public static string ChartMaker = "SUNORAPI";
    public static float MusicTime = 3.7f;
    public static int LPB = 4;
    void Start()
    {
        PathI = PathI.GetComponent<TMP_InputField>();
        BPMI = BPMI.GetComponent<TMP_InputField>();
        BeatPerMeasureI = BeatPerMeasureI.GetComponent<TMP_InputField>();
        LevelI = LevelI.GetComponent<TMP_InputField>();
        ComposerI = ComposerI.GetComponent<TMP_InputField>();
        ChartMakerI = ChartMakerI.GetComponent<TMP_InputField>();
        MusicTimeI = MusicTimeI.GetComponent<TMP_InputField>();

        PathText = PathText.GetComponent<TextMeshProUGUI>();
        BPMText = BPMText.GetComponent<TextMeshProUGUI>();
        BeatPerMeasureText = BeatPerMeasureText.GetComponent<TextMeshProUGUI>();
        LevelText = LevelText.GetComponent<TextMeshProUGUI>();
        ComposerText = ComposerText.GetComponent<TextMeshProUGUI>();
        ChartMakerText = ChartMakerText.GetComponent<TextMeshProUGUI>();
        MusicTimeText = MusicTimeText.GetComponent<TextMeshProUGUI>();
    }
    public void InputPath()
    {
        if (!string.IsNullOrEmpty(PathI.text))
        {
            PathText.text = PathI.text;
            Path = PathI.text.ToString();
        }
    }
    public void InputBPM()
    {
        if (!string.IsNullOrEmpty(BPMI.text))
        {
            BPMText.text = BPMI.text;
            BPM = float.Parse(BPMI.text.ToString());
        }
    }
    public void InputBPMeasure()
    {
        if (!string.IsNullOrEmpty(BeatPerMeasureI.text))
        {
            BeatPerMeasureText.text = BeatPerMeasureI.text;
            BeatPerMeasure = int.Parse(BeatPerMeasureI.text.ToString());
        }
    }
    public void InputLevel()
    {
        if (!string.IsNullOrEmpty(LevelI.text))
        {
            LevelText.text = LevelI.text;
            Level = int.Parse(LevelI.text.ToString());
        }
    }
    public void InputComposer()
    {
        if (!string.IsNullOrEmpty(ComposerI.text))
        {
            ComposerText.text = ComposerI.text;
            Composer = ComposerI.text.ToString();
        }
    }
    public void InputChartMaker()
    {
        if (!string.IsNullOrEmpty(ChartMakerI.text))
        {
            ChartMakerText.text = ChartMakerText.text;
            ChartMaker = ChartMakerI.text.ToString();
        }
    }
    public void InputMusicTime()
    {
        if (!string.IsNullOrEmpty(MusicTimeI.text))
        {
            MusicTimeText.text = MusicTimeI.text;
            MusicTime = float.Parse(MusicTimeI.text.ToString());
        }
    }

    public void InputLPB()
    {
        if (!string.IsNullOrEmpty(LPBI.text))
        {
            LPBText.text = LPBI.text;
            LPB = int.Parse(LPBI.text.ToString());
        }
    }
}

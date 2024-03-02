using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class ChartCalculator : MonoBehaviour
{
    static float TPB;//Time Per Beat
    public static float TPL;//Time Per Line
    float Offset;
    float NoteTime;
    float MPM;//Measure Per Minute
    int MeasureNumber;//è¨êﬂÇÃêî
    int LPB;
    public static int LineNumber;

    void Start()
    {
        TPB = 60000 / SetInput.BPM;
        MPM = SetInput.BPM / SetInput.BeatPerMeasure;
        MeasureNumber = Mathf.CeilToInt(MPM * SetInput.MusicTime) + 1;
        LineNumber = MeasureNumber * SetInput.BeatPerMeasure * LPB;
        TPL = TPB / LPB;
    }
}

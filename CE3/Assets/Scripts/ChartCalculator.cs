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
    public static int LineNumber;

    void Start()
    {
        TPB = 60 / SetInput.BPM;
        TPL = TPB / SetInput.LPB;
        LineNumber = Mathf.CeilToInt( SetInput.BPM * SetInput.LPB * SetInput.MusicTime)+1;
    }
}

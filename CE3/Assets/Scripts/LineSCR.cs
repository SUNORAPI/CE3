using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.VFX;
using Unity.Collections;
using UnityEngine.EventSystems;
using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using static UnityEditor.PlayerSettings;

class Note
{
    public int NoteX;
    public int NoteY;
    public UnityEngine.UI.Image NObj;
}


public class LineSCR : MonoBehaviour
{
    public static int[] LinePos = new[] { -200, -150, -100, -50, 0, 50, 100, 150, 200 };
    private int _NowNum0;
    private int _LaneNum;
    private int _NoteLength;
    private int _NoteType;
    private int[] _LineNum = new int[9];
    List<Note> NoteList = new List<Note>();
    private List<Vector2> VNL_Pos = new List<Vector2>();
    public UnityEngine.UI.Image NPrefab;
    public GameObject P;
    private void Start()
    {
        
    }

    private void Update()
    {
        for(int i = 0; i < 9; i++)
        {
            _LineNum[i] = _NowNum0 + i;
        }
        _NowNum0 = (int)Mathf.Floor(MusicButton.NowMusicTime/ChartCalculator.TPL);
        var VNL = NoteList.Where( note => note.NoteY >= _NowNum0 && note.NoteY <= _NowNum0 +8).ToList();//表示するノーツのリスト
        foreach (var note in VNL)
        {
            float posX = -382 + note.NoteX * 47;
            float posY = LinePos[note.NoteY - _NowNum0];
            Vector2 pos = new Vector2(posX, posY);
            Draw(pos, note.NObj);
        }
    }

    void Draw(Vector2 VNL_Pos,UnityEngine.UI.Image NO)
    {
        NO.rectTransform.anchoredPosition = VNL_Pos;
        NO.rectTransform.sizeDelta = new Vector2(47, 10);
    }
    public void AddN(Vector2 V)
    {
        float posX = -382 + V.x * 47;
        float posY = LinePos[(int)V.y];
        Vector2 pos = new Vector2(posX, posY);
        UnityEngine.UI.Image Obj = Instantiate(NPrefab, pos, Quaternion.identity);
        Obj.transform.SetParent(P.transform);
        NoteList.Add(new Note { NoteX = (int)V.y, NoteY = (int)V.y + _NowNum0, NObj = Obj});
    }
}

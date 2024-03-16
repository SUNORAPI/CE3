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

class Note
{
    public int NoteX;
    public int NoteY;
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
    public GameObject NPrefab;
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
        NoteList.Add (new Note { NoteX = MusicButton.BposX, NoteY = MusicButton.BposY + _NowNum0});
        var VNL = NoteList.Where( note => note.NoteY >= _NowNum0 && note.NoteY <= _NowNum0 +8).ToList();//表示するノーツのリスト
        foreach (var note in VNL)
        {
            float posX = -382 + note.NoteX * 47;
            float posY = LinePos[note.NoteY - _NowNum0];
            VNL_Pos.Add(new Vector2(posX, posY));
        }
        Draw(VNL_Pos);
    }

    void Draw(List<Vector2> VNL_Pos)
    {
        foreach (var pos in VNL_Pos)
        {
            GameObject Obj = Instantiate(NPrefab, pos, Quaternion.identity);
            Vector2 scale = new Vector2(47f, 10f);
            Obj.transform.localScale = scale;
        }
    }
}

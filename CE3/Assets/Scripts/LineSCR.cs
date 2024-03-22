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
using UnityEditorInternal;
using System.IO;

[System.Serializable]
public class Chart
{
    public string Title;
    public string Composer;
    public string ChartMaker;
    public float BPM;
    public int Level;
    public List<SaveNote> Notes;
}
[System.Serializable]
public class SaveNote
{
    public int SNX;
    public float SNY;
}
class Note
{
    public int NoteX;
    public int NoteY;
    public UnityEngine.UI.Image NObj;
}


public class LineSCR : MonoBehaviour
{
    public static int[] LinePosY = new[] { -200, -150, -100, -50, 0, 50, 100, 150, 200 };
    public static int[] LinePosX = new[] {-382 ,-335, -288, -241, -194, -147, -100, -53, -6, 41, 88, 135, 182, 229, 276, 323};
    private int _NowNum0;
    private int _LaneNum;
    private int _NoteLength;
    private int _NoteType;
    private int[] _LineNum = new int[9];
    List<Note> NoteList = new List<Note>();
    List<SaveNote> SaveNoteList = new List<SaveNote>();
    private List<Vector2> VNL_Pos = new List<Vector2>();
    public UnityEngine.UI.Image NPrefab;
    public GameObject P;
    string filepath;
    public Chart data;
    private void Awake()
    {
        Debug.Log("LineSCR.cs awaked.");
        filepath = Application.dataPath + "/" + SetInput.Title + ".json"; //JSONのファイルパス
        if (!File.Exists(filepath))
        {
            Init();
        }
        else
        {
            Debug.Log("Succes S02: Find the json file. path: "+ filepath);
        }
    }

    private void Update()
    {
        MusicButton.NNUM = _NowNum0;
        for(int i = 0; i < 9; i++)
        {
            _LineNum[i] = _NowNum0 + i;
        }
        _NowNum0 = (int)Mathf.Floor(MusicButton.NowMusicTime/ChartCalculator.TPL);
        var VNL = NoteList.Where( note => note.NoteY >= _NowNum0 && note.NoteY <= _NowNum0 +8).ToList();//表示するノーツのリスト
        var NonVNL = NoteList.Where( note => note.NoteY < _NowNum0 || note.NoteY > _NowNum0 +8).ToList();//表示しないノーツのリスト
        foreach (var note in VNL)
        {
            float posX = LinePosX[note.NoteX];
            float posY = LinePosY[note.NoteY - _NowNum0];
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
        float posX = LinePosX[(int)V.x];
        float posY = LinePosY[(int)V.y];
        Vector2 pos = new Vector2(posX, posY);
        UnityEngine.UI.Image Obj = Instantiate(NPrefab, pos, Quaternion.identity);
        Obj.rectTransform.SetParent(P.transform, false);
        Obj.rectTransform.anchoredPosition = pos;
        NoteList.Add(new Note { NoteX = (int)V.x, NoteY = (int)V.y + _NowNum0, NObj = Obj});
        SaveNoteList.Add(new SaveNote { SNX = (int)V.x, SNY = ((int)V.y + _NowNum0) * ChartCalculator.TPL });
    }
    void Save(List<SaveNote> Nls)
    {
        data.Title = SetInput.Title;
        data.Composer = SetInput.Composer;
        data.ChartMaker = SetInput.ChartMaker;
        data.BPM = SetInput.BPM;
        data.Level = SetInput.Level;
        if (Nls != null)
        {
            data.Notes = Nls;
        }
        string json = JsonUtility.ToJson(data);
        using (StreamWriter Swr = new StreamWriter(filepath, false))
        {
            Swr.WriteLine(json);
            Debug.Log("Succes S03: Saved chart on the json file.");
        }
    }
    void Init()
    {
        data.Title = SetInput.Title;
        data.Composer = SetInput.Composer;
        data.ChartMaker = SetInput.ChartMaker;
        data.BPM = SetInput.BPM;
        data.Level = SetInput.Level;
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        using (StreamWriter Swr = new StreamWriter(filepath, false))
        {
            Swr.WriteLine(json);
        }
        Debug.Log("Succes S01: Inited the json file. path: " +  filepath);
    }
    public void Savebtn()
    {
        Save(SaveNoteList);
    }
}

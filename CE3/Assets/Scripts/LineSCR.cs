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
using JetBrains.Annotations;

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
    public int SNM;
    public int SNX;
    public float SNY;
}
class Note
{
    public int NoteX;
    public int NoteY;
    public int NoteMode;
    public UnityEngine.UI.Image NObj;
}


public class LineSCR : MonoBehaviour
{
    public static int[] LinePosY = new[] { -200, -150, -100, -50, 0, 50, 100, 150, 200 };
    public static int[] LinePosX = new[] {-382 ,-335, -288, -241, -194, -147, -100, -53, -6, 41, 88, 135, 182, 229, 276, 323};
    public static int Notesmode;
    private int _NowNum0;
    private int _LaneNum;
    private int _NoteLength;
    private int _NoteType;
    private int[] _LineNum = new int[9];
    Note SelectNote;
    List<Note> NoteList = new List<Note>();
    List<SaveNote> SaveNoteList = new List<SaveNote>();
    private List<Vector2> VNL_Pos = new List<Vector2>();
    public UnityEngine.UI.Image NPrefab;
    public GameObject P;
    string filepath;
    public Chart data;
    string[] Colorstr = new string[] { "#00BFFF", "#FF1493" };
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
            Draw(pos, note.NObj, note.NoteMode);
        }
    }
    void Draw(Vector2 VNL_Pos,UnityEngine.UI.Image NO, int Mode)
    {
        Color Notemodecolor;
        UnityEngine.ColorUtility.TryParseHtmlString(Colorstr[Mode], out Notemodecolor);
        NO.rectTransform.anchoredPosition = VNL_Pos;
        NO.rectTransform.sizeDelta = new Vector2(47, 10);
        NO.color = Notemodecolor;
    }
    public void AddN(Vector2 V, int Mode)
    {
        Color Notemodecolor;
        UnityEngine.ColorUtility.TryParseHtmlString(Colorstr[Mode], out Notemodecolor);
        float posX = LinePosX[(int)V.x];
        float posY = LinePosY[(int)V.y];
        Vector2 pos = new Vector2(posX, posY);
        UnityEngine.UI.Image Obj = Instantiate(NPrefab, pos, Quaternion.identity);
        Obj.rectTransform.SetParent(P.transform, false);
        Obj.rectTransform.anchoredPosition = pos;
        Obj.color = Notemodecolor;
        NoteList.Add(new Note { NoteX = (int)V.x, NoteY = (int)V.y + _NowNum0, NObj = Obj, NoteMode = Mode});
    }
    void Save()
    {
        data.Title = SetInput.Title;
        data.Composer = SetInput.Composer;
        data.ChartMaker = SetInput.ChartMaker;
        data.BPM = SetInput.BPM;
        data.Level = SetInput.Level;
        SaveNoteList.Clear();
        foreach (Note note in NoteList)
        {
            SaveNoteList.Add(new SaveNote { SNX = note.NoteX, SNY = note.NoteY * ChartCalculator.TPL, SNM = note.NoteMode });
        }
        if (SaveNoteList != null)
        {
            data.Notes = SaveNoteList;
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
        Save();
    }

    public void NoteButton(int X, int Y)
    {
        if(SelectNote != null)
        {
            Outline outline = SelectNote.NObj.GetComponent<Outline>();
            Destroy(outline);
        }
        SelectNote = null;
        Vector2 BV2 = new Vector2(X, Y);
        SelectNote = NoteList.Find(Nf => Nf.NoteX == X && Nf.NoteY == Y + _NowNum0);
        if (SelectNote != null)
        {
            Notesmode = SelectNote.NoteMode;
            SelectNote.NObj.AddComponent<Outline>();
            Outline outline = SelectNote.NObj.GetComponent<Outline>();
            outline.effectColor = Color.yellow;
            outline.effectDistance = new Vector2(4, 4);
        }
        else
        {
            AddN(BV2, Notesmode);
        }
    }
    public void Notemodechange(int mode)     
    {
        if (SelectNote != null)
        {
            SelectNote.NoteMode = mode;
        }
    }
    
}

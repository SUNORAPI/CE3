using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Liner : MonoBehaviour
{
    public Image Line;
    public GameObject Lines;
    public float Speed;
    void Start()
    {

        var a =ChartCalculator.LineNumber + 1; //テスト用、下のfor文のi<に入れる

       for (int i = 0; i < 100;  i++)
       {
            var space = -200 + 50 * i;
            Image CloneLine = Instantiate(Line);
            CloneLine.rectTransform.SetParent(Lines.transform,false);
            CloneLine.rectTransform.anchoredPosition = new Vector2(-75, space);
       } 
    }
}

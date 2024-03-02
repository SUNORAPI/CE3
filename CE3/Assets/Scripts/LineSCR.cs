using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.VFX;

public class LineSCR : MonoBehaviour
{
    float Speed;
    float leng;
    float MoveLength;
    RectTransform Line;
    float fx;
    float fy;
    private void Start()
    {
        Line = this.gameObject.GetComponent<RectTransform>();
        fx = Line.position.x;
        fy = Line.position.y;
        leng = ChartCalculator.TPL * ChartCalculator.LineNumber;
        Speed = 20 / ChartCalculator.TPL;
    }
    private void Update()
    {
        var pos =new Vector2(fx, fy + Speed * MusicButton.SliderValue);
        Line.anchoredPosition = pos;
        /*
        動作に不具合アリ。線が表示されず、音楽再生も不安定。要修正
        */
    }
}

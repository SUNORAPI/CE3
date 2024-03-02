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
        ����ɕs��A���B�����\�����ꂸ�A���y�Đ����s����B�v�C��
        */
    }
}

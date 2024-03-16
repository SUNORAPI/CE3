using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]public GameObject SB;
    private void Update()
    {
        if (!(string.IsNullOrEmpty(SetInput.Path) || string.IsNullOrEmpty(SetInput.Composer) || string.IsNullOrEmpty(SetInput.ChartMaker) || string.IsNullOrEmpty(SetInput.BPM.ToString()) || string.IsNullOrEmpty(SetInput.BeatPerMeasure.ToString()) || string.IsNullOrEmpty(SetInput.Level.ToString()) || string.IsNullOrEmpty(SetInput.MusicTime.ToString()) || string.IsNullOrEmpty(SetInput.LPB.ToString())))
        {
            SB.SetActive(true);
        }
        else
        {
            SB.SetActive(false);
        }
    }
    public void StartB()
    {
        SceneManager.LoadScene("Edit");
    }
}

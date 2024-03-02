using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    private void Start()
    {
        Load(SetInput.Path);
    }
    public void Load(string MPath)
    {
        if (Path.GetExtension(MPath) == ".m4a")
        {
            Debug.Log("Error 01: .m4a audio format is not supported.");
        }
        else 
        {
            StartCoroutine(LoadAudio(MPath));
        }
    }
    IEnumerator LoadAudio(string Path)
    {
        if (audioSource == null || string.IsNullOrEmpty(Path))
        {
            yield break;
        }
        if (!File.Exists(Path))
        {
            Debug.Log("Error 02: File not found.");
            yield break;
        }
        using(WWW www = new WWW("file://" + Path))
        {
            while (!www.isDone)
                yield return null;
            AudioClip audioClip = www.GetAudioClip(false, true);
            if(audioClip.loadState != AudioDataLoadState.Loaded)
            {
                Debug.Log("Error 03: Failed to load AudioClip.");
                yield break;
            }
            audioSource.clip = audioClip;
            Debug.Log("Success to Load: " + Path);
        }
    }
}

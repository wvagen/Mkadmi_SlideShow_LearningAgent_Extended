using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;

public class MS_SlideShow_Vid : MonoBehaviour
{
    public Text videoMomentTxt;
    public VideoPlayer videoPlayer;

    public float videoStartMoment;

    private void OnEnable()
    {
        if (videoStartMoment > 0)
        {
            videoPlayer.time = videoStartMoment;
        }
    }

    void Update()
    {
        videoMomentTxt.text = ((int)videoPlayer.time).ToString() + " / " + ((int)videoPlayer.length).ToString();
    }
}

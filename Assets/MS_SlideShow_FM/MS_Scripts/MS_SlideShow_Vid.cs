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
    public float videoSpeed = 1;

    private void OnEnable()
    {
        if (videoStartMoment > 0)
        {
            videoPlayer.time = videoStartMoment;
        }

        videoPlayer.playbackSpeed = videoSpeed;
    }

    void Update()
    {
        videoMomentTxt.text = ((int)videoPlayer.time).ToString() + " / " + ((int)videoPlayer.length).ToString();

        if (Input.GetKeyDown(KeyCode.Alpha1)) videoPlayer.playbackSpeed = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) videoPlayer.playbackSpeed = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) videoPlayer.playbackSpeed = 3;
    }
}

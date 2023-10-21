using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvController : MonoBehaviour
{
    public GameObject screen;
    public VideoClip[] channels;

    bool on;
    int currentChannel;
    VideoPlayer screenVideoPlayer;

    void Start()
    {
        screenVideoPlayer = screen.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) ToggleTvPower();
        else if (Input.GetKeyDown(KeyCode.R)) NextChannel();
        else if (Input.GetKeyDown(KeyCode.F)) PreviousChannel();
    }

    void ToggleTvPower()
    {
        on = !on;
        screen.SetActive(on);
    }

    void NextChannel()
    {
        if (currentChannel < channels.Length - 1) currentChannel+= 1;
        else currentChannel = 0;
        
        ChangeScreenChannel();
    }

    void PreviousChannel()
    {
        if (currentChannel > 0) currentChannel-= 1;
        else currentChannel = channels.Length - 1;

        ChangeScreenChannel();
    }

    void ChangeScreenChannel()
    {
        screenVideoPlayer.clip = channels[currentChannel];
        screenVideoPlayer.Play();
    }
}

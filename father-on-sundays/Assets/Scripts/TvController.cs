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
    float normalCameraView = 60, zoomCameraView = 20, currentCameraView, zoomSpeed = 5;
    VideoPlayer screenVideoPlayer;
    Camera playerCamera;

    void Start()
    {
        screenVideoPlayer = screen.GetComponent<VideoPlayer>();
        GameObject playerCameraObject = GameObject.FindWithTag("MainCamera");
        playerCamera = playerCameraObject.GetComponent<Camera>();
        currentCameraView = normalCameraView;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) ToggleTvPower();
        else if (Input.GetKeyDown(KeyCode.R)) NextChannel();
        else if (Input.GetKeyDown(KeyCode.F)) PreviousChannel();

        CameraZoom();
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

    void CameraZoom()
    {
        float targetCameraView = Input.GetKey(KeyCode.LeftControl) ? zoomCameraView : normalCameraView;
        currentCameraView = Mathf.Lerp(currentCameraView, targetCameraView, zoomSpeed * Time.deltaTime);
        playerCamera.fieldOfView = currentCameraView;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvController : MonoBehaviour
{
    public Animator beerAnimator;
    public AudioSource drinkBeerAudio, changeChannelAudio;

    public GameObject screen, woman, son;
    public VideoClip[] channels;

    public SojaExiles.MouseLook cameraMouseLook;

    bool on, inGameMenu = true;
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
        if (inGameMenu) return;

        CameraZoom();

        if (Input.GetKeyDown(KeyCode.Q)) DrinkBeer();

        if (Input.GetKeyDown(KeyCode.E)) ToggleTvPower();
        else if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.R)) NextChannel();
        else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.F)) PreviousChannel();
    }

    public void ToggleInGameMenu()
    {
        inGameMenu = !inGameMenu;
        cameraMouseLook.enabled = !inGameMenu;
        woman.SetActive(!inGameMenu);
        son.SetActive(!inGameMenu);
        GameObject.FindGameObjectWithTag("GameMenu").SetActive(inGameMenu);
    }

    void ToggleTvPower()
    {
        on = !on;
        screen.SetActive(on);
    }

    public void TurnOffTv()
    {
        on = false;
        screen.SetActive(on);
    }

    void NextChannel()
    {
        if (!on) return;

        if (currentChannel < channels.Length - 1) currentChannel+= 1;
        else currentChannel = 0;
        
        ChangeScreenChannel();
    }

    void PreviousChannel()
    {
        if (!on) return;

        if (currentChannel > 0) currentChannel-= 1;
        else currentChannel = channels.Length - 1;

        ChangeScreenChannel();
    }

    void ChangeScreenChannel()
    {
        changeChannelAudio.Play();
        screenVideoPlayer.clip = channels[currentChannel];
        screenVideoPlayer.Play();
    }

    void CameraZoom()
    {
        float targetCameraView = Input.GetKey(KeyCode.LeftControl) ? zoomCameraView : normalCameraView;
        currentCameraView = Mathf.Lerp(currentCameraView, targetCameraView, zoomSpeed * Time.deltaTime);
        playerCamera.fieldOfView = currentCameraView;
    }

    void DrinkBeer()
    {
        beerAnimator.SetTrigger("Drink");
		StartCoroutine(DrinkAudioDelay());
    }

    IEnumerator DrinkAudioDelay()
    {
        yield return new WaitForSeconds(0.5f);
        drinkBeerAudio.Play();
    }
}

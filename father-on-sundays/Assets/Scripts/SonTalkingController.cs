using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonTalkingController : MonoBehaviour
{
    public Animator sonDoorAnimator;

    bool isTalking;
    float talkingTimerDuration = 11;
    AudioSource sonVoice;
    TvController tvController;

    void Start()
    {
        sonVoice = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        tvController = player.GetComponent<TvController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && !isTalking) StartCoroutine(Talking());
    }

    IEnumerator Talking()
    {
        isTalking = true;
        tvController.TurnOffTv();
        sonDoorAnimator.Play("Opening");

        yield return new WaitForSeconds(0.5f);

        sonVoice.Play();

        yield return new WaitForSeconds(talkingTimerDuration);

        sonDoorAnimator.Play("Closing");
        isTalking = false;
    }
}

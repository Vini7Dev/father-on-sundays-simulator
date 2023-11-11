using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanTalkingController : MonoBehaviour
{
    bool isTalking;
    float talkingTimerDuration = 9;
    Animator womanAnimator;
    AudioSource womanVoice;
    TvController tvController;

    void Start()
    {
        womanAnimator = GetComponent<Animator>();
        womanVoice = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        tvController = player.GetComponent<TvController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isTalking) StartCoroutine(Talking());
    }

    IEnumerator Talking()
    {
        isTalking = true;
        tvController.TurnOffTv();
        womanAnimator.SetBool("Talking", true);

        yield return new WaitForSeconds(1);

        womanVoice.Play();

        yield return new WaitForSeconds(talkingTimerDuration);

        womanAnimator.SetBool("Talking", false);
        isTalking = false;
    }
}

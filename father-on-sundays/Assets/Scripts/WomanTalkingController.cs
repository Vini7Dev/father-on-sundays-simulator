using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanTalkingController : MonoBehaviour
{
    bool isTalking;
    float talkingTimerDuration = 9;
    Animator womanAnimator;
    AudioSource womanVoice;

    void Start()
    {
        womanAnimator = GetComponent<Animator>();
        womanVoice = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isTalking) StartCoroutine(Talking());
    }

    IEnumerator Talking()
    {
        isTalking = true;
        womanAnimator.SetBool("Talking", true);

        yield return new WaitForSeconds(1);

        womanVoice.Play();

        yield return new WaitForSeconds(talkingTimerDuration);

        womanAnimator.SetBool("Talking", false);
        isTalking = false;
    }
}

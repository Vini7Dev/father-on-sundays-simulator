using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonTalkingController : MonoBehaviour
{
    public Animator sonDoorAnimator;

    bool isTalking;
    float talkingTimerDuration = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && !isTalking) StartCoroutine(Talking());
    }

    IEnumerator Talking()
    {
        isTalking = true;
        sonDoorAnimator.Play("Opening");

        yield return new WaitForSeconds(talkingTimerDuration);

        sonDoorAnimator.Play("Closing");
        isTalking = false;
    }
}

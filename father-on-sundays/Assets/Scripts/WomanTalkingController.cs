using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanTalkingController : MonoBehaviour
{
    bool isTalking;
    float talkingTimerDuration = 5;
    Animator womanAnimator;

    void Start()
    {
        womanAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isTalking) StartCoroutine(Talking());
    }

    IEnumerator Talking()
    {
        isTalking = true;
        womanAnimator.SetBool("Talking", true);

        yield return new WaitForSeconds(talkingTimerDuration);

        womanAnimator.SetBool("Talking", false);
        isTalking = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitThePlayer : MonoBehaviour
{
    private bool isSitting;

    public Transform sittingPositionOnTheSofa;

    private PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        isSitting = false;
        TogglePlayerIsSitting();
    }


    public void TogglePlayerIsSitting() {
        isSitting = !isSitting;

        if (isSitting) {
            SeatThePlayer();
        } else {
            LiftThePlayer();
        }
    }

    void SeatThePlayer() {
        playerMovement.enabled = false;
        transform.position = sittingPositionOnTheSofa.position;
        transform.rotation = sittingPositionOnTheSofa.rotation;
    }

    void LiftThePlayer() {
        playerMovement.enabled = true;
    }

    void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.E)) {
            TogglePlayerIsSitting();
        }
    }
}

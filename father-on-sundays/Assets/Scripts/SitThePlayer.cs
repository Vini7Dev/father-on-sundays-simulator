using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitThePlayer : MonoBehaviour
{
    private bool isSitting;

    public Transform sittingPositionOnTheSofaTransform;
    public GameObject televisionController;

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
        transform.position = sittingPositionOnTheSofaTransform.position;
        transform.rotation = sittingPositionOnTheSofaTransform.rotation;
        televisionController.SetActive(true);
    }

    void LiftThePlayer() {
        televisionController.SetActive(false);
        playerMovement.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + 2,
            transform.position.z
        );
        playerMovement.enabled = true;
    }

    void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.Q)) {
            TogglePlayerIsSitting();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitThePlayer : MonoBehaviour
{
    public bool defaultIsSitting = true, enableToLift;

    public Transform sittingPositionOnTheSofaTransform;
    public GameObject televisionController;

    private bool isSitting;
    private PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        isSitting = !defaultIsSitting;
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
            transform.position.z - 2
        );
        playerMovement.enabled = true;
    }

    void OnTriggerStay(Collider other) {
        if (enableToLift && Input.GetKeyDown(KeyCode.Q)) {
            TogglePlayerIsSitting();
        }
    }
}

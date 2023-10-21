using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour
{
    private bool on;

    public GameObject screen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleTvPower();
        }
    }

    void ToggleTvPower()
    {
        on = !on;

        screen.SetActive(on);

        if (on) TurnOn();
        else TurnOff();
    }

    void TurnOn()
    {
        //
    }

    void TurnOff()
    {
        //
    }
}

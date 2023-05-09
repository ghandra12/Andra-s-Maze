using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private GameObject flashlight;
    private GameObject pointlight;
    private void Start()
    {
        flashlight = GameObject.FindWithTag("Flashlight");
        pointlight = GameObject.FindWithTag("FlashlightLight");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight.GetComponent<FlashlightTrigger>().EnteredTrigger)
            {
                pointlight.GetComponent<Light>().enabled = !pointlight.GetComponent<Light>().enabled;
            }
        }
     }
}

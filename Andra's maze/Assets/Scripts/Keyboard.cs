using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (flashlight.GetComponent<FlashlightTrigger>().enteredTrigger)
            {
                pointlight.GetComponent<Light>().enabled = !pointlight.GetComponent<Light>().enabled;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

     }
}

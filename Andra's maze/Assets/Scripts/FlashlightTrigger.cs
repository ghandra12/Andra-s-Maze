using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashlightTrigger : MonoBehaviour
{
    public bool enteredTrigger;
    private GameObject flashlight;
    private GameObject flashlightText;

    private void Start()
    {
        flashlight = GameObject.FindWithTag("Flashlight");
        flashlightText = GameObject.FindWithTag("FlashlightText");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube")
        {
            enteredTrigger = true;
            StartCoroutine("ShowFlashlightMessage");
            flashlight.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private IEnumerator ShowFlashlightMessage()
    {
        flashlightText.GetComponent<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(10);
        flashlightText.GetComponent<TMP_Text>().enabled = false;
    }
}

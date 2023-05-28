using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    private GameObject keypadScreen;
    private GameObject pressEToUseText;
    [SerializeField] private KeyPad keypad;
    private bool canDisplayKeypad;
    void Start()
    {
        keypadScreen = GameObject.FindGameObjectWithTag("KeypadScreen");
        pressEToUseText = GameObject.FindWithTag("PressEToUse");
        keypadScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDisplayKeypad && !keypad.doorOpened)
        {
            if (keypadScreen.activeSelf)
            {
                keypad.ans.text = string.Empty;
                Cursor.lockState = CursorLockMode.Locked;
                keypadScreen.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                keypadScreen.SetActive(true);
            }
        }
    }
    private IEnumerator ShowPressEToUse()
    {
        pressEToUseText.GetComponent<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(10);
        pressEToUseText.GetComponent<TMP_Text>().enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !keypad.doorOpened)
        {
            canDisplayKeypad = true;
            StartCoroutine("ShowPressEToUse");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canDisplayKeypad = false;
            Cursor.lockState = CursorLockMode.Locked;
            pressEToUseText.GetComponent<TMP_Text>().enabled = false;
            keypadScreen.SetActive(false);
        }
    }
}

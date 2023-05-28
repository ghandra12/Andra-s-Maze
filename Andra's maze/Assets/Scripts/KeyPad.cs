using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField] public TMP_Text ans;
    private GameObject secondDoor;
    private string correctPincode = "1212";
    public bool doorOpened = false;

    public void Start()
    {
        secondDoor = GameObject.FindWithTag("SecondDoor");
    }
    public void Number(int number)
    {
        if (ans.text.Length < 4)
        {
            ans.text += number.ToString();
        }
    }

    public void Confirm()
    {
        if (ans.text == correctPincode && !doorOpened)
        {
            ans.text = "OK";
            secondDoor.transform.position = new Vector3(294.78f, 0.87f, -334.1f);
            secondDoor.transform.Rotate(0, -100f, 0.0f, Space.Self);
            doorOpened = true;
        } else
        {
            ans.text = "NO";
        }
    }
}

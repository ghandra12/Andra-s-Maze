using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private TMP_Text ans;

    public void Number(int number)
    {
        if (ans.text.Length < 4)
        {
            ans.text += number.ToString();
        }
    }
}

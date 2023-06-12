using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        string playerName = GameObject.FindWithTag("PlayerName").GetComponent<TMP_InputField>().text;

        using (FileStream fs = new FileStream("temp.txt", FileMode.OpenOrCreate))
        {
            using (StreamWriter w = new StreamWriter(fs))
            {
                w.Write(playerName);
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject endOfGameCamera;
    public GameObject endOfGameText;
    DateTime startTime;
    public TimeSpan timeElapsed { get; private set; }
    // Start is called before the first frame update

    void Start()
    {
        startTime = DateTime.Now;
        player = GameObject.FindWithTag("Player");
        endOfGameCamera = GameObject.FindWithTag("EndOfGameCamera");
        endOfGameText = GameObject.FindWithTag("EndText");
    }

    // Update is called once per frame
    void Update()
    {
        this.timeElapsed = DateTime.Now - startTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.SetActive(false);
            endOfGameText.GetComponent<TMP_Text>().text += $"Score: {(int)timeElapsed.TotalSeconds}";
            endOfGameCamera.GetComponent<Camera>().enabled = true;
            endOfGameText.GetComponent<TMP_Text>().enabled = true;
        }
    }
}

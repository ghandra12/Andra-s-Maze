using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject endOfGameCamera;
    public GameObject endOfGameText;
    // Start is called before the first frame update
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        endOfGameCamera = GameObject.FindWithTag("EndOfGameCamera");
        endOfGameText = GameObject.FindWithTag("EndText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.SetActive(false);
            endOfGameCamera.GetComponent<Camera>().enabled = true;
            endOfGameText.GetComponent<TMP_Text>().enabled = true;
        }
    }
}

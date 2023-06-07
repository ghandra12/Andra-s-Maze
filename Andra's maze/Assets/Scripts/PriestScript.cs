using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PriestScript : MonoBehaviour
{
    public bool canMove = false;
    private GameObject player;
    public float movementSpeed = 1.5f;
    public GameObject endOfGameCamera;
    public GameObject endOfGameText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        endOfGameCamera = GameObject.FindWithTag("EndOfGameCamera");
        endOfGameText = GameObject.FindWithTag("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube")
        {
            player.SetActive(false);
            endOfGameCamera.GetComponent<Camera>().enabled = true;
            endOfGameText.GetComponent<TMP_Text>().enabled = true;
        }
    }

}

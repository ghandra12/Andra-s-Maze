using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapTrigger : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = new Vector3(8, 2, -385);
        }
    }
}

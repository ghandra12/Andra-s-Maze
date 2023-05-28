using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReturnToPosition2 : MonoBehaviour
{
    public GhostScript ghost;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube")
        {
            ghost.returnToStart = false;
        }
    }
}

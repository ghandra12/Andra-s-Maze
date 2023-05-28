using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReturnPosition1Script : MonoBehaviour
{
    public GhostScript ghost;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube")
        {
            ghost.returnToStart = true;
        }
    }
}

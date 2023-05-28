using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube")
        {
            gameObject.SetActive(false);
        }
    }
}

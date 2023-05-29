using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapScript : MonoBehaviour {

    public Animator spikeTrapAnim; 
    public bool reverse = false;

    // Use this for initialization
    void Awake()
    {
        spikeTrapAnim = GetComponent<Animator>();
        if (reverse)
        {
            StartCoroutine(ReverseOpenCloseTrap());
        }
        else
        {
            StartCoroutine(OpenCloseTrap());
        }
    }

    IEnumerator OpenCloseTrap()
    {
        spikeTrapAnim.SetTrigger("open");
        yield return new WaitForSeconds(2);
        spikeTrapAnim.SetTrigger("close");
        yield return new WaitForSeconds(2);
        StartCoroutine(OpenCloseTrap());
    }

    IEnumerator ReverseOpenCloseTrap()
    {
        yield return new WaitForSeconds(2);
        spikeTrapAnim.SetTrigger("open");
        yield return new WaitForSeconds(2);
        spikeTrapAnim.SetTrigger("close");
        StartCoroutine(ReverseOpenCloseTrap());
    }
}
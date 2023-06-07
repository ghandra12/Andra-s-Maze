using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThirdKeyTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject runText;
    private GameObject key;
    private GameObject fifthDoor;
    [SerializeField] private PriestScript priest;

    private void Start()
    {
        runText = GameObject.FindWithTag("RunText");
        key = GameObject.FindWithTag("key3");
        fifthDoor = GameObject.FindWithTag("FifthDoor");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube" && key.GetComponent<MeshRenderer>().enabled)
        {
            StartCoroutine("ShowKeyPickedUpMessage");
            key.GetComponent<MeshRenderer>().enabled = false;
            priest.canMove = true;
            fifthDoor.transform.position = new Vector3(13.71f, 0.87f, -565.2599f);
            fifthDoor.transform.Rotate(0, -110f, 0.0f, Space.Self);
        }
    }
    private IEnumerator ShowKeyPickedUpMessage()
    {
        runText.GetComponent<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(10);
        runText.GetComponent<TMP_Text>().enabled = false;
    }
}

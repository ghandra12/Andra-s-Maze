using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Key_TriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject doorText;
    private GameObject key;
    private GameObject firstDoor;

    private void Start()
    {
        doorText = GameObject.FindWithTag("DoorOpen");
        key = GameObject.FindWithTag("key");
        firstDoor = GameObject.FindWithTag("FirstDoor");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube" && key.GetComponent<MeshRenderer>().enabled)
        {
            StartCoroutine("ShowDoorOpenMessage");
            key.GetComponent<MeshRenderer>().enabled = false;
            firstDoor.transform.position = new Vector3(295.9f, 0.87f, -74);
            firstDoor.transform.Rotate(0, -100f, 0.0f, Space.Self);
        }
    }
    private IEnumerator ShowDoorOpenMessage()
    {
        doorText.GetComponent<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(10);
        doorText.GetComponent<TMP_Text>().enabled = false;
    }
}

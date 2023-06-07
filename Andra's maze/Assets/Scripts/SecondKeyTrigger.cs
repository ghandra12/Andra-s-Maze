using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondKeyTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject doorText;
    private GameObject key;
    private GameObject fourthDoor;

    private void Start()
    {
        doorText = GameObject.FindWithTag("DoorOpen");
        key = GameObject.FindWithTag("key2");
        fourthDoor = GameObject.FindWithTag("FourthDoor");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube" && key.GetComponent<MeshRenderer>().enabled)
        {
            StartCoroutine("ShowDoorOpenMessage");
            key.GetComponent<MeshRenderer>().enabled = false;
            fourthDoor.transform.position = new Vector3(284.78f, 0.87f, -566.8f);
            fourthDoor.transform.Rotate(0, -100f, 0.0f, Space.Self);
        }
    }
    private IEnumerator ShowDoorOpenMessage()
    {
        doorText.GetComponent<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(10);
        doorText.GetComponent<TMP_Text>().enabled = false;
    }
}

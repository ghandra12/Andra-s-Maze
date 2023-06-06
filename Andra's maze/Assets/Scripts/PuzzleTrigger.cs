using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    private GameObject puzzleScreen;
    private GameObject pressEToUseText;
    [SerializeField] private Puzzle puzzle;
    private bool canDisplayPuzzle;
    void Start()
    {
        puzzleScreen = GameObject.FindGameObjectWithTag("PuzzleScreen");
        pressEToUseText = GameObject.FindWithTag("PressEToUse");
        puzzleScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDisplayPuzzle && !puzzle.doorOpened)
        {
            if (puzzleScreen.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                puzzleScreen.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                puzzleScreen.SetActive(true);
            }
        }
    }
    private IEnumerator ShowPressEToUse()
    {
        pressEToUseText.GetComponent<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(10);
        pressEToUseText.GetComponent<TMP_Text>().enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !puzzle.doorOpened)
        {
            canDisplayPuzzle = true;
            StartCoroutine("ShowPressEToUse");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canDisplayPuzzle = false;
            Cursor.lockState = CursorLockMode.Locked;
            pressEToUseText.GetComponent<TMP_Text>().enabled = false;
            puzzleScreen.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    [SerializeField] private GameObject endTarget;
    [SerializeField] private GameObject startTarget;
    [SerializeField] private GameObject ghostReturnPosition1;
    [SerializeField] private GameObject ghostReturnPosition2;

    private GameObject player;

    public bool returnToStart = true;
    private bool moveForward = true;
    public float movementSpeed = 1.5f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCube")
        {
            if (returnToStart)
            {
                player.transform.position = ghostReturnPosition1.transform.position;
            }
            else
            {
                player.transform.position = ghostReturnPosition2.transform.position;
            }
        }
    }

    void Update()
    {
        if (moveForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, endTarget.transform.position, movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endTarget.transform.position) < 0.001f)
            {
                moveForward = false;
                transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startTarget.transform.position, movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startTarget.transform.position) < 0.001f)
            {
                moveForward = true;
                transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            }
        }
    }
}

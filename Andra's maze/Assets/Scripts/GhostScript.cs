using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    [SerializeField] private GameObject endTarget;
    [SerializeField] private GameObject startTarget;
    private bool moveForward = true;
    public float movementSpeed = 1.5f;
    void Start()
    {
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

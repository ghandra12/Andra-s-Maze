using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private List<int> order = new List<int>(){ 1, 2, 3, 4, 8, 5, 7, 6, -1 };
    private List<int> correctOrder = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, -1 };
    [SerializeField] private List<Transform> cubes;
    private Transform auxCube;
    private int aux;
    private Vector3 auxPosition;
    public bool doorOpened = false;
    private GameObject thirdDoor;
    void Start()
    {
        thirdDoor = GameObject.FindWithTag("ThirdDoor");
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (order.SequenceEqual(correctOrder) && !doorOpened)
        {
            doorOpened = true;
            thirdDoor.transform.position = new Vector3(212.97f, 0.87f, -514.3f);
            thirdDoor.transform.Rotate(0, 100f, 0.0f, Space.Self);
        }
    }

    public void SwitchElements(int element)
    {
        if (element != 0)
        {
            var value = order.FindIndex(m => m == element);

            var switchWith = -1;
            if (value + 1 <= 8 && order[value + 1] == -1)
            {
                switchWith = value + 1;
            }

            if (value - 1 >= 0 && order[value - 1] == -1)
            {
                switchWith = value - 1;
            }

            if (value + 3 <= 8 && order[value + 3] == -1)
            {
                switchWith = value + 3;
            }

            if (value - 3 >= 0 && order[value - 3] == -1)
            {
                switchWith = value - 3;
            }

            if (switchWith != -1)
            {
                aux = order[switchWith];
                order[switchWith] = order[value];
                order[value] = aux;

                auxPosition = cubes[switchWith].position;
                cubes[switchWith].position = cubes[value].position;
                cubes[value].position = auxPosition;

                auxCube = cubes[switchWith];
                cubes[switchWith] = cubes[value];
                cubes[value] = auxCube;
                

            }

        }
    }
}

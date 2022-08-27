using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap : MonoBehaviour
{
    public float sawSpeed;
    private float z;
    public GameObject point1, point2;
    private Vector2 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = point2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rotateTrap();
        moveTrap();
    }

    private void rotateTrap()
    {
        z = z + Time.deltaTime * 500;
        transform.rotation = Quaternion.Euler(0, 0, z);

    }

    private void moveTrap()
    {
        if (transform.position == point1.transform.position)
        {
            nextPos = point2.transform.position;
        }
        if (transform.position == point2.transform.position)
        {
            nextPos = point1.transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, nextPos, sawSpeed * Time.deltaTime);
    }
}

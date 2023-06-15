using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    Vector2[] offsets;

    [SerializeField]
    GameObject cube;

    

    private bool hasCollided;
    private int maxLeftX;
    private int maxRightX;


    private void Start()
    {
        maxLeftX = 0;
        maxRightX = 0;  

        foreach (Vector2 offset in offsets)
        {
            GameObject newCube = Instantiate(cube, transform);
            newCube.transform.localPosition = new Vector3(offset.x, offset.y);

            maxLeftX = (int) Math.Min(maxLeftX, offset.x);
            maxRightX = (int) Math.Max(maxRightX, offset.x);

        }

        StartCoroutine(moveDown());
    }

    private void Update()
    {
        Movement.handleHorizontalMovement(transform, maxLeftX, maxRightX);
    }

    IEnumerator moveDown()
    {
        while (true)
        {
            transform.position += Vector3.down;
            yield return new WaitForSeconds(.5f);
        }

    }
}

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

    // used to make sure block doesn't go out of bounds
    private int maxLeftX;
    private int maxRightX;


    private void Start()
    {
        generateBlock();
       
        StartCoroutine(moveDown());
    }

    private void Update()
    {
        Movement.handleHorizontalMovement(transform, maxLeftX, maxRightX);

        if (Movement.handleRotation(offsets, transform))
        {
            generateBlock();
        }

    }

    IEnumerator moveDown()
    {
        while (true)
        {
            transform.position += Vector3.down;
            yield return new WaitForSeconds(.5f);
        }

    }

    private void generateBlock()
    {
        maxLeftX = 0;
        maxRightX = 0;

        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }


        foreach (Vector2 offset in offsets)
        {
            GameObject newCube = Instantiate(cube, transform);

            // add offset to each cube
            newCube.transform.localPosition = new Vector3(offset.x, offset.y);

            maxLeftX = (int) Math.Min(maxLeftX, offset.x);
            maxRightX = (int )Math.Max(maxRightX, offset.x);

        }
    }
}

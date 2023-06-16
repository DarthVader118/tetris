using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Movement
{
    private const float LEFTBOUND = -7;
    private const float RIGHTBOUND = 7;

    public static void handleHorizontalMovement(Transform transform, int maxLeftX, int maxRightX)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x + maxLeftX > LEFTBOUND)
        {
            transform.position += Vector3.left; 
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x + maxRightX < RIGHTBOUND)
        { 
            transform.position += Vector3.right; 
        }
    }

    // return true or false to allow for block to regenerate itself
    public static bool handleRotation(Vector2[] offsets, Transform transform)
    {
        Vector2[] rotatedOffsets = new Vector2[offsets.Length];
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            for (int i = 0; i < offsets.Length; i++)
            {
                Vector2 offset = offsets[i];

                Vector2 currRotatedOffset = offset.x * new Vector2(0, -1) + offset.y * new Vector2(1, 0);

                if (currRotatedOffset.x + transform.position.x < LEFTBOUND || currRotatedOffset.x + transform.position.x > RIGHTBOUND)
                {
                    return false;
                }

                rotatedOffsets[i] = currRotatedOffset;
            }

            for (int i = 0; i < offsets.Length; i++)
            {
                offsets[i] = rotatedOffsets[i];
            }

            return true;
        }

        return false;
    }
}

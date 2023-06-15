using System.Collections;
using System.Collections.Generic;
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
}

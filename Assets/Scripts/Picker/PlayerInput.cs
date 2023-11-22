using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float lastFrameTouchPositionX;
    private float dragAmount;
    private bool isDragging;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastFrameTouchPositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            float newTouchPositionX = Input.mousePosition.x; 
            dragAmount = newTouchPositionX - lastFrameTouchPositionX;
            lastFrameTouchPositionX = newTouchPositionX;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    public float GetDragAmount()
    {
        return dragAmount;
    }

    public bool IsDragging()
    {
        return isDragging;
    }
}

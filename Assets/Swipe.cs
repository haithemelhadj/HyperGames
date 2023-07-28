using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    public Vector2 firstTouchPosition;
    public Vector2 finalTouchPosition;
    public float swipeAngle = 0f;

    public GameObject otherCofee;
    public Board board;

    public int posX;
    public int posY;
    public int column;
    public int row;
    // Start is called before the first frame update

    void Start()
    {
        board = FindObjectOfType<Board>();
        posX= (int)transform.position.x;
        posY= (int)transform.position.y;
        row = posY;
        column = posX;      
    }

    // Update is called once per frame
    void Update()
    {
        posX = column;
        posY = row;
    }

    private void OnMouseDown()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Mouse Down = "+firstTouchPosition);
    }

    private void OnMouseUp()
    {
        finalTouchPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Mouse Up = "+finalTouchPosition);
        CalculateAngle();
    }

    private void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
        Debug.Log("Swipe Angle = "+swipeAngle);
        SwitchPlaces();
    }

    string SwitchPlaces() //switch cofee positions
    {
        //var dir = "";
        if (swipeAngle <= 45f && swipeAngle > -45f && column < board.width) //right
        {
            otherCofee = board.allCofees[column + 1, row];
            otherCofee.GetComponent<Swipe>().column=-1;
            column++;
            return "right";
        }
        else if (swipeAngle <= 135f && swipeAngle > 45f && row < board.height) //up
        {
            otherCofee = board.allCofees[column, row + 1];
            otherCofee.GetComponent<Swipe>().row = -1;
            row++;
            return "up";
        }
        else if ((swipeAngle > 135f && swipeAngle < -135f) && column > 0) //left
        {
            otherCofee = board.allCofees[column - 1, row];
            otherCofee.GetComponent<Swipe>().column=+1;
            column--;
            return "left";
        }
        else if (swipeAngle > -135f && swipeAngle < -45f && row>0) //down
        {
            otherCofee = board.allCofees[column, row - 1];
            otherCofee.GetComponent<Swipe>().row = +1;
            row--;
            return "down";
        }
        return "none";
    }
}

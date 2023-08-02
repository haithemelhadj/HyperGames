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

        //Vector2 tempPosition = new Vector2(posX, posY);
        //GetComponentInParent<Transform>().transform.position = tempPosition;//move towards 
        



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
            otherCofee.GetComponentInChildren<Swipe>().column=-1;
            column++;
            return "right";
        }
        else if (swipeAngle <= 135f && swipeAngle > 45f && row < board.height) //up
        {
            Debug.Log("1");
            otherCofee = board.allCofees[column, row + 1];
            Debug.Log("2");
            otherCofee.GetComponentInChildren<Swipe>().row = -1;
            Debug.Log("3");
            row++;
            return "up";
        }
        else if ((swipeAngle > 135f && swipeAngle < -135f) && column > 0) //left
        {
            otherCofee = board.allCofees[column - 1, row];
            otherCofee.GetComponentInChildren<Swipe>().column=+1;
            column--;
            return "left";
        }
        else if (swipeAngle > -135f && swipeAngle < -45f && row>0) //down
        {
            otherCofee = board.allCofees[column, row - 1];
            otherCofee.GetComponentInChildren<Swipe>().row = +1;
            row--;
            return "down";
        }
        return "none";
    }


    /*
    void CheckForThree()
    {
        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject currentCofee = board.allCofees[i, j];
                if (currentCofee != null)
                {
                    if (i > 0 && i < board.width - 1)
                    {
                        GameObject leftCofee = board.allCofees[i - 1, j];
                        GameObject rightCofee = board.allCofees[i + 1, j];
                        if (leftCofee != null && rightCofee != null)
                        {
                            if (leftCofee.tag == currentCofee.tag && rightCofee.tag == currentCofee.tag)
                            {
                                Destroy(leftCofee);
                                Destroy(rightCofee);
                                Destroy(currentCofee);
                                //leftCofee.GetComponentInChildren<Swipe>().column = -1;
                                //rightCofee.GetComponentInChildren<Swipe>().column = -1;
                                //currentCofee.GetComponentInChildren<Swipe>().column = -1;
                            }
                        }
                    }
                    if (j > 0 && j < board.height - 1)
                    {
                        GameObject upCofee = board.allCofees[i, j + 1];
                        GameObject downCofee = board.allCofees[i, j - 1];
                        if (upCofee != null && downCofee != null)
                        {
                            if (upCofee.tag == currentCofee.tag && downCofee.tag == currentCofee.tag)
                            {
                                Destroy(upCofee);
                                Destroy(downCofee);
                                Destroy(currentCofee);
                                //upCofee.GetComponentInChildren<Swipe>().row = -1;
                                //downCofee.GetComponentInChildren<Swipe>().row = -1;
                                //currentCofee.GetComponentInChildren<Swipe>().row = -1;
                            }
                        }
                    }
                }   

            }
        }
    }                               
    */
}

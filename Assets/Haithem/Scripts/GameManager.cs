using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Board board;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckForThree();
    }

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




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessingManager : MonoBehaviour
{
    public int Length;
    public int width;
    public GameObject[,] allCards;
    public GameObject[] cardsList;

    public enum GameState
    {
        noCardsFlipped,
        oneCardFlipped,
        twoCardsFlipped,
        gameEnded
    }

    private void Awake()
    {
        allCards = new GameObject[Length, width];
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < width / 2; j++) 
            {
                if (allCards[i, j] == null)
                {
                    GameObject tempCard = cardsList[Random.Range(0, cardsList.Length)];
                    allCards[i, j] = tempCard;
                    allCards[Length - i, width - j] = tempCard;
                    
                }
            }
        }
        ShuffleArray(allCards);
    }

    void ShuffleArray(GameObject[,] array)
    {
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int x = Random.Range(0, Length);
                int y = Random.Range(0, width);
                //permutation
                GameObject tempObj= array[x, y];
                array[x,y] = array[i,j];
                array[i,j] = tempObj; 
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //spawn cards depending on resolution and spacing
        //when spawinging put them all in one gameObject so that they can be put in gamemanager
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //Vector2 tempPosition = new Vector2(i, j);
                Vector2 tilePosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(allCards[i,j], tilePosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + ", " + j + " )";
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

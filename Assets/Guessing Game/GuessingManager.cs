using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GuessingManager : MonoBehaviour
{
    #region declaring variables
    //[Header("")]
    [Header("UI & Menu")]
    public GameObject winMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject pauseButton;

    [Header("PLayer Stats")]
    public int score;
    public int scoreScaler;
    private float timer;
    public float initTimer;
    public GameObject Timerline;
    private Vector3 lineScale = new Vector3(0.4f, 0.3f, 0f);
    public int flips;
    [Header("PLayer Stats Text")]

    public Text scoreText;
    public Text timerText;
    public Text flipsText;
    [Header("game logic and rules")]
    public int width;//width width
    public int Length;//Length Length
    //public GameObject Card;

    public GameObject[,] allCards;
    public GameObject[] cardsList;
    public GameState gameState;



    [Header("Other")]
    public int NumberOfSolvedCards;
    public int TotalCards;
    public float tileSpacing = 0.1f;
    public float offset;

    #endregion

    public enum GameState
    {
        ongoing,
        paused,
        ended
    }

    #region awake,start,update
    private void Awake()
    {
        Time.timeScale = 1f;

        TotalCards = Length * width;

        if (Length % 2 != 0) Length++;
        allCards = new GameObject[this.width, this.Length];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < Length/2 ; j++) 
            {
                if (allCards[i, j] == null)
                {
                    GameObject tempCard = cardsList[Random.Range(0, cardsList.Length)];
                    allCards[i, j] = tempCard;
                    allCards[width - 1 - i, Length - 1 - j] = tempCard;
                    
                    
                }
            }
        }
        //ShuffleArray(allCards);
        for (int i = 0; i < this.width; i++)
        {
            for (int j = 0; j < this.Length; j++)
            {
                int x = Random.Range(0, this.width);
                int y = Random.Range(0, this.Length);
                //permutation
                GameObject tempObj = allCards[x, y];
                allCards[x, y] = allCards[i, j];
                allCards[i, j] = tempObj;
            }
        }
    }

    void Start()
    {
        #region inistilasing
        TotalCards = Length * width;
        timer = initTimer;

        float verticalOffset = tileSpacing;
        float horizontalOffset = tileSpacing;

        timerText.text = "Timer: " + timer.ToString();
        #endregion
        //spawn cards depending on resolution and spacing
        //when spawinging put them all in one gameObject so that they can be put in gamemanager
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < Length; j++)
            {
                //Vector2 tempPosition = new Vector2(i, j);
                Vector2 tilePosition = new Vector2(i+horizontalOffset, j + verticalOffset);
                verticalOffset += tileSpacing;
                GameObject backgroundTile = Instantiate(allCards[i,j], tilePosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + ", " + j + " )";
            }
            verticalOffset = tileSpacing;
            horizontalOffset += tileSpacing;
        }
        Camera.main.transform.position = new Vector3((float)width / 2 - 0.5f, ((float)Length / 2 - 0.5f) + offset, -10f);


    }

    void Update()
    {
        
        //timer and check for loss
        if(gameState==GameState.ongoing)
        {
            //check for win
            if (TotalCards == NumberOfSolvedCards)
            {
                Time.timeScale = 0;
                winMenu.SetActive(true);
                gameState = GameState.ended;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = "Timer: " + Mathf.Floor(timer).ToString();
                //make a line that shortens over time  
                //lineScale.x= ((((timer*100)/initTimer)*100f)/4);
                //Timerline.transform.localScale = lineScale;
            }
            else
            {
                timerText.text = "GameOver";
                Debug.Log("game over");
                gameState = GameState.ended;
                gameOverMenu.SetActive(true);
            }
        }
        
    }

    #endregion


    #region Buttons

    public void Pause()
    {
        Time.timeScale = 0f;
        gameState = GameState.paused;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Resumse()
    {
        Time.timeScale = 1;
        gameState = GameState.ongoing;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    #endregion

}

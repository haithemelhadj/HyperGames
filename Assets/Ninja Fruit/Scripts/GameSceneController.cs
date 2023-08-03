using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public int numberOfLives;
    public ObjectSpawner fruitSpawner;
    public ObjectSpawner bombSpawner;
    public Text ScoreText;
    public LifeCounter LifeCounter;
    public GameObject gameOverGroup;
    public GameObject ramenimg;
    public Cut cut;

    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            ScoreText.text = "" + score;
        }
    }
    void Start()
    {
        ramenimg.gameObject.SetActive(true);
        cut.gameObject.SetActive(true);
        fruitSpawner.gameObject.SetActive(true);
        bombSpawner.gameObject.SetActive(true);
        gameOverGroup.SetActive(false);
        LifeCounter.SetLives(numberOfLives);
        fruitSpawner.OnObjectSpawned += OnObjectSpawned;
        bombSpawner.OnObjectSpawned += OnObjectSpawned;
        Score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnObjectSpawned(CuttableObj obj)
    {
        obj.OnDestroyed += OnObjectDestroyed;
    }
    private void OnObjectDestroyed(bool harmful)
    {
        if (!harmful)
        {
            Score += 10;
        }
        else
        {
            LoseLife();
        }
    }
    private void LoseLife()
    {
        numberOfLives--;
        LifeCounter.LoseLife();
        if(numberOfLives <= 0)
        {
            ramenimg.gameObject.SetActive(false);
            cut.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(false);
            gameOverGroup.gameObject.SetActive(true);
            Text gameOvertext = gameOverGroup.GetComponentInChildren<Text>();
            gameOvertext.text = string.Format(gameOvertext.text, score);
            fruitSpawner.gameObject.SetActive(false);
            bombSpawner.gameObject.SetActive(false);
        }
    }
}

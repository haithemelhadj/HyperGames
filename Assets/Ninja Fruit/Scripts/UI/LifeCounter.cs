using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public int numberOfLives;
    public GameObject LifePrefab;
    public GameObject ScoreText;
    public GameObject gameOverGroup;
    public GameObject img;
    private List<GameObject> lives;

   
    public void SetLives(int amount)
    {
        lives = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject lifeInstance = Instantiate(LifePrefab, transform);
            lives.Add(lifeInstance);
        }
    }

   public void LoseLife()
    {
        
        GameObject lastLife = lives[lives.Count-1];
        lives.Remove(lastLife);
        Destroy(lastLife);
    }
}

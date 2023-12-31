using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    
    public int Score;
    public int addPoints = 10;
    public GameObject Object;
    public void LoadScene(string sceneName)
    {
        Debug.Log("Going to " + sceneName);
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
        if ((sceneName == "GuessThe Dress" || sceneName == "CofeeCrash" || sceneName == "NujaFruit"))// && ScoreText != null) 
        {
            Debug.Log("adding points");
            PointsManager.UserPoints = PointsManager.UserPoints + addPoints;
            
            //Debug.Log(PointsManager.UserPoints);
            //Debug.Log("playerprefs = "+PlayerPrefs.GetInt("userPoints"));
        }
    }

    public void SetObjectInactive()
    {
        Debug.Log("inActive");
        
        Object.SetActive(false);
    }

    public void SetObjectActive()
    {
        Debug.Log("Active");
        Object.SetActive(true);
    }


}
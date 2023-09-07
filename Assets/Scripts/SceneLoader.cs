using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    
    public int Score;
    public int addPoints = 10;
    
    public void LoadScene(string sceneName)
    {
        Debug.Log("Going to " + sceneName);
        SceneManager.LoadScene(sceneName);
        if ((sceneName == "GuessThe Dress" || sceneName == "CofeeCrash" || sceneName == "NujaFruit"))// && ScoreText != null) 
        {
            Debug.Log("adding points");
            PointsManager.UserPoints = PointsManager.UserPoints + addPoints;
            
            //Debug.Log(PointsManager.UserPoints);
            //Debug.Log("playerprefs = "+PlayerPrefs.GetInt("userPoints"));
        }
    }
}
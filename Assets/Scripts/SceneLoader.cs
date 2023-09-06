using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Text ScoreText;
    public int Score;
    public void LoadScene(string sceneName)
    {
        Debug.Log("Going to " + sceneName);
        SceneManager.LoadScene(sceneName);
        if(sceneName=="HomeMenu")
        {
            ScoreText.text = "Points:" + Score+50f;
        }
    }
}
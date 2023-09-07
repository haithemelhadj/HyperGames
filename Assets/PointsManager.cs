using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text ScoreText;
    //public Text Points;
    public static int UserPoints;
    //public PlayerPrefs userPoints;
    // Start is called before the first frame update
    void Start()
    {
        //UserPoints=PlayerPrefs.GetInt("UserPoints");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("prefs : " + PlayerPrefs.GetInt("UserPoints"));
        //Debug.Log("userP : " + UserPoints);
        ScoreText.text = "Points: " + UserPoints;
        //PlayerPrefs.SetInt("userPoints", PointsManager.UserPoints);

    }
}

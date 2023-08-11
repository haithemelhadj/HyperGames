using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cofeeGame()
    {
        //go to scene with lable "cofeeGAme"
        SceneManager.LoadScene("CofeeCrash");
    }
    public void NinjaFruit()
    {
        SceneManager.LoadScene("NujaFruit");
    }
    public void beautyGame()
    {
        SceneManager.LoadScene("GuessThe Dress");
    }
    public void Spinwheel()
    {
        SceneManager.LoadScene("");
    }
    public void Rewards()
    {
        SceneManager.LoadScene("");
    }
}

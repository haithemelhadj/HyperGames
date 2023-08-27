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
        SceneManager.LoadScene("coffeelevels");
    }
    public void NinjaFruit()
    {
        SceneManager.LoadScene("foodlevels");
    }
    public void beautyGame()
    {
        SceneManager.LoadScene("coifflevels");
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

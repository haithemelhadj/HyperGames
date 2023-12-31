using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheel : MonoBehaviour
{
    public GameObject Wheel;
    public int Spins = 5;
    public Rigidbody2D rb;
    //public int numberOfColors;
    public string[] colors;
    public int x = -1;
    public float rotation;
    bool alreadySpinned = false;
    public GameObject Reward;
    public GameObject spinWheelGroup;
    //public Text numberOfSpins;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //numberOfColors = colors.width;
        //numberOfSpins.text = "Spins: "+Spins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.angularVelocity<0.001 && alreadySpinned)//check if the wheel is already spinned and check for reward result
        {
            Reward.SetActive(true);
            alreadySpinned = false;
            spinWheelGroup.SetActive(false);
        }
        /*
        //Debug.Log(rb.angularVelocity);
        if(rb.angularVelocity<0.9f )// && rb.angularVelocity>0.01f)
        {
            //rotation = Wheel.transform.localRotation.eulerAngles .z;
            if (Wheel.transform.localRotation.eulerAngles.z <= 180f)
            {
                rotation = Wheel.transform.localRotation.eulerAngles.z;
            }
            else
            {
                rotation = Wheel.transform.localRotation.eulerAngles.z - 360f;
            }
            //x = Mathf.RoundToInt(rotation / colors.width);
            if (rotation>=0 && rotation < 45)
            {
                x = 0;
            }
            else if (rotation >= 45 && rotation < 90)
            {
                x = 1;
            }
            else if (rotation >= 90 && rotation < 135)
            {
                x = 2;
            }
            else if (rotation >= 135 && rotation < 180)
            {
                x = 3;
            }
            else if (rotation >= -45 && rotation < 0)
            {
                x = 7;
            }
            else if (rotation >= -90 && rotation < -45)
            {
                x = 6;
            }
            else if (rotation >= -135 && rotation < -90)
            {
                x = 5;
            }
            else if (rotation >= -180 && rotation < -135)
            {
                x = 4;
            }
            else
            {
                x = -1;
            }
            //Debug.Log(rotation);
            Debug.Log(colors[x]);
        }
        */
    }

    public void Spin()
    {
        if(Spins>=1 && rb.angularVelocity < 0.01f && !alreadySpinned)
        {

            //Debug.Log("spin");
            //spin the wheel with random force 2D
            Wheel.GetComponent<Rigidbody2D>().AddTorque(Random.Range(1000, 4000));
            Invoke("ChangeBoolVal", 1f);
            Spins--;
            //numberOfSpins.text = "Spins: "+Spins.ToString();
        }else if( Spins<1)
        {
            spinWheelGroup.SetActive(false);

        }
    }

    private void ChangeBoolVal()
    {
        alreadySpinned = true;
    }

    public void GetASpin()
    {
        Spins++;
        //numberOfSpins.text = "Spins: " + Spins.ToString();
    }
}

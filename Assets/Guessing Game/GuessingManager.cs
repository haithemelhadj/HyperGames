using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessingManager : MonoBehaviour
{
    public GameObject[] setClothes;
    public GameObject[] eyes;
    public GameObject[] nose;
    public GameObject[] mouth;



    // Start is called before the first frame update
    void Start()
    {
        setClothes[0] = eyes[Random.Range(0, eyes.Length)];
        setClothes[1] = nose[Random.Range(0, nose.Length)];
        setClothes[2] = mouth[Random.Range(0, mouth.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

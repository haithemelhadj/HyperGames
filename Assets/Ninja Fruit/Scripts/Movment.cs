using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [Header("Speed Variables")]
    public float maximumXSpeed;
    public float minimumXSpeed;
    public float maximumYSpeed;
    public float minimumYspeed;
    [Header("Gameplay Variables")]
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minimumXSpeed, maximumXSpeed), Random.Range(minimumYspeed, maximumYSpeed));
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

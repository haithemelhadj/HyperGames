using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CuttableObj : MonoBehaviour
{
    public delegate void ObjectDestoyedHandler(bool harmful);
    public event ObjectDestoyedHandler OnDestroyed;

public bool harmful;
    public int addScore = 10;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cut")
        {
            if (OnDestroyed != null)
            {
                OnDestroyed(harmful);
            }
            Destroy(gameObject);
            if (!harmful)
            {
                
              //?
               
            }
            else
            {
                //?
               
            }
        }
    }
    
}

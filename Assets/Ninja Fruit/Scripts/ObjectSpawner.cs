using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject prefab;
    public Sprite[] sprites;
    public float intervale;
    public float minimumX;
    public float maximumX;
    public float y;
    
    void Start()
    {
        InvokeRepeating("Spawn", intervale, intervale);
    }

   private void Spawn()
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(Random.Range(minimumX, maximumX), y);
        Sprite RandomSprite = sprites[Random.Range(0, sprites.Length)];
        instance.GetComponent<SpriteRenderer>().sprite = RandomSprite;
    }
}

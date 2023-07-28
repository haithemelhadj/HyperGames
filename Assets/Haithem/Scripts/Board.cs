using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width; // board width
    public int height;//board height

    public GameObject tilePrefab;// background tile prefab
    private BackgroundTile[,] allTiles;// double array of all background tiles

    public GameObject CoffePrefab; // temprorary coffee prefab

    public GameObject[,] allCofees; // double array of all cofee on the board

    public GameObject[] cofeeTypes; // array of cofee types prefabs
    


    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allCofees = new GameObject[width, height];
        SetUp();
    }


    

    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {        
            for (int j = 0; j < height; j++)
            {
                //spawn backgroundTiles
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity);
                backgroundTile.transform.parent = this.transform; 
                backgroundTile.name = "T (" + i + ", " + j + " )";
                //spawn objects
                int dotToUse = Random.Range(0, cofeeTypes.Length);
                GameObject dot = Instantiate(cofeeTypes[dotToUse], tempPosition, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "C (" + i + ", " + j + " )";
                allCofees[i, j] = dot;


                //allcofees[i,j].get component . column= (int)transform.position.x;
                //row= (int)transform.position.y;

                //GameObject CofeeType = Instantiate(CoffePrefab, tempPosition,Quaternion.identity);
                //backgroundTile.transform.parent = this.transform; backgroundTile.name = "( " + i + ", " + j + " )";
            }
        }
    }
}
/*
 * get the position of the cofee and turn it into numbers in swipe script
 * get from the board array the cofee in specific direction 
 * 
 * 
 * 
 * switch this cofee's position with the other cofee position in the scene
 * also switch their places in the board 
 * */
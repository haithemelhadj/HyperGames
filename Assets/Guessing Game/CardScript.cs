using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CardScript : MonoBehaviour
{
    public GuessingManager guessingManager;

    public static List<CardScript> Cards = new List<CardScript>();//duplicate 

    private SpriteRenderer rend;
    //public GameObject GameManager;

    [SerializeField]
    public Sprite faceSprite, backSprite;
    [SerializeField] private Collider2D coll;

    private bool coroutineAllowed, facedUp;
    //[SerializeField] private bool TouchingPlayer = false;
    [SerializeField] private float WaitTimer;

    // Start is called before the first frame update
    void Start()
    {
        guessingManager = FindObjectOfType<GuessingManager>();
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = backSprite;
        coroutineAllowed = true;
        facedUp = false;
        guessingManager.flipsText.text = "Flips: " + guessingManager.flips.ToString();
        guessingManager.scoreText.text = "Score: " + guessingManager.score.ToString();
        //Debug.Log("start");
        
    }
    //-------------------------------------------------------
    public void RotateCardCoroutineCalled()
    {
        StartCoroutine(RotateCard());
    }
    //-------------------------------------------------------

    public void Update()
    {
        


        if (Input.touchCount > 0 || Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            //Vector2 touchPosition = (GameManager.MainCamera.ScreenToWorldPoint(touch.position));
            //ray cast on touch position to check if it hits the card
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (guessingManager.gameState==GuessingManager.GameState.ongoing && hit.collider != null)
            {
                //Debug.Log("hit");
                if (hit.collider.gameObject == this.gameObject)
                {
                    if (coroutineAllowed && Input.touchCount == 1 && Cards.Count < 2 && !facedUp)//receive input
                    {
                        StartCoroutine(RotateCard());
                        Cards.Add(this);
                        guessingManager.flips++;
                        guessingManager.flipsText.text = "Flips: " + guessingManager.flips.ToString();
                        //GameManager.CheckCards();

                        Debug.Log("count=" + Cards.Count);
                    }
                }
            }

        }
    }

    public IEnumerator RotateCard()
    {
        coroutineAllowed = false;

        if (!facedUp)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    rend.sprite = faceSprite;
                }
                yield return new WaitForSeconds(WaitTimer);
            }
        }

        else if (facedUp)
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    rend.sprite = backSprite;
                }
                yield return new WaitForSeconds(WaitTimer);
            }
        }

        coroutineAllowed = true;

        facedUp = !facedUp;
        //-------- i added this
        if (Cards.Count >= 2 && Cards[0].facedUp && Cards[1].facedUp)
        {


            if (Cards[0].faceSprite.name == Cards[1].faceSprite.name) // check if the two cards have the same face sprite
            {
                //9erd yawli ya3ml sound for 5secs w yzid fel speed
                //Cards[0].SetCollToInactive();//set the card collider to inactive from card script
                Cards[0].gameObject.SetActive(false);
                //Cards[1].SetCollToInactive();
                Cards[1].gameObject.SetActive(false);
                Debug.Log("cards are the same");                
                guessingManager.score += guessingManager.scoreScaler;
                guessingManager.scoreText.text = "Score: " + guessingManager.score.ToString();
                guessingManager.scoreScaler += 5;
                guessingManager.NumberOfSolvedCards += 2;

                
            }
            else if (Cards[0].faceSprite.name != Cards[1].faceSprite.name)//check if the two cards have different face sprites
            {

                Cards[0].RotateCardCoroutineCalled();//rotate both cards if not the same
                Cards[1].RotateCardCoroutineCalled();
                Debug.Log("cards are not the same");
                guessingManager.scoreScaler = guessingManager.scoreScaler==1 ? 1 : guessingManager.scoreScaler - 1;

            }
            else//print error if there is an error
            {
                Debug.Log("error");
            }
            Cards.Clear();//clear list of 2 cards to fill with two new cards if player picks two new cards

        }




        //-------end my add
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player is in the trigger");
            //TouchingPlayer = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player is in the trigger");
            //TouchingPlayer = false;

        }
    }
    public void SetCollToInactive()
    {
        coll.enabled = false;
    }
}

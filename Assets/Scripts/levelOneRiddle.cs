using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelOneRiddle : MonoBehaviour
{
    
    public Text keyText;
    public Text endText;

    bool redRiddle = true;
    bool orangeRiddle = false;
    bool yellowRiddle = false;
    bool greenRiddle = false;
    bool homeRiddle = false;

    bool carrotActive = false;
    bool eggActive = false;
    bool watermelonActive = false;
    bool donutActive = false;
    bool fiveCheck = false;

    /*bool carrotPossible = false;
    bool eggPossible = false;
    bool watermelonPossible = false;
    bool donutPossible = false;
    bool homePossible = false;

    bool redCanTalk = false;
    bool orangeCanTalk = false;
    bool yellowCanTalk = false;
    bool greenCanTalk = false;*/

    public AudioSource interactSound, pickUpSound;

    bool hitRed, hitOrange, hitYellow, hitGreen;

    public GameObject exclamationPoint, exclamationPoint2;
    public Transform pointOne, pointTwo, pointThree, pointFour, pointFive; //three and four are first
    private Transform currentPoint;

    public GameObject carrotSprite, eggSprite, watermelonSprite, donutSprite;
    public SpriteRenderer redSprite, orangeSprite, yellowSprite, greenSprite;
    public Color shadeColor, noColor;

    //black screen stuff//
    public bool fading = false;
    public SpriteRenderer blackScreen;
    private Color fadeColor;
    public float alpha = 1;

    float cameraLeft, cameraRight, cameraBottom, cameraTop;
    float cameraDist = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        exclamationPoint2.SetActive(false);
        currentPoint = pointThree;
        orangeSprite.color = shadeColor;
        yellowSprite.color = shadeColor;
        greenSprite.color = shadeColor;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); //finding screen location
        Vector2 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        cameraLeft = lowerLeft.x + cameraDist;
        cameraBottom = lowerLeft.y + cameraDist;
        cameraRight = upperRight.x - cameraDist;
        cameraTop = upperRight.y - cameraDist;

        if (fading == true){
            Debug.Log("fading");
            
            if (alpha < 1){
                alpha += .003f;
            } else {
                SceneManager.LoadScene("levelTwoV2");
            }
        } else {
            if (alpha > 0){
                alpha -= .01f;
            }
        }

        fadeColor = new Color(0, 0, 0, alpha);
        blackScreen.color = fadeColor;

        if (exclamationPoint.activeInHierarchy){
            exclamationPoint.transform.position = Vector3.Lerp(exclamationPoint.transform.position, currentPoint.position, 0.007f);

            if (exclamationPoint.transform.position.x > cameraRight)
            {
                exclamationPoint.transform.position = new Vector3(cameraRight, exclamationPoint.transform.position.y, exclamationPoint.transform.position.z);
            }

            if (exclamationPoint.transform.position.x < cameraLeft)
            {
                exclamationPoint.transform.position = new Vector3(cameraLeft, exclamationPoint.transform.position.y, exclamationPoint.transform.position.z);
            }

            if (exclamationPoint.transform.position.y > cameraTop)
            {
                exclamationPoint.transform.position = new Vector3(exclamationPoint.transform.position.x, cameraTop, exclamationPoint.transform.position.z);
            }

            if (exclamationPoint.transform.position.y < cameraBottom)
            {
                exclamationPoint.transform.position = new Vector3(exclamationPoint.transform.position.x, cameraBottom, exclamationPoint.transform.position.z);
            }
        }

        if (exclamationPoint2.activeInHierarchy){
            exclamationPoint2.transform.position = Vector3.Lerp(exclamationPoint2.transform.position, currentPoint.position, 0.007f);

            if (exclamationPoint2.transform.position.x > cameraRight)
            {
                exclamationPoint2.transform.position = new Vector3(cameraRight, exclamationPoint2.transform.position.y, exclamationPoint2.transform.position.z);
            }

            if (exclamationPoint2.transform.position.x < cameraLeft)
            {
                exclamationPoint2.transform.position = new Vector3(cameraLeft, exclamationPoint2.transform.position.y, exclamationPoint2.transform.position.z);
            }

            if (exclamationPoint2.transform.position.y > cameraTop)
            {
                exclamationPoint2.transform.position = new Vector3(exclamationPoint2.transform.position.x, cameraTop, exclamationPoint2.transform.position.z);
            }

            if (exclamationPoint2.transform.position.y < cameraBottom)
            {
                exclamationPoint2.transform.position = new Vector3(exclamationPoint2.transform.position.x, cameraBottom, exclamationPoint2.transform.position.z);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        
        if(other.gameObject.name == "red_0" && redRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "HELP ME FIND SOMETHING THAT IS \nORANGE AND SOUNDS LIKE PARROT!";

                exclamationPoint.SetActive(false); //upon interaction, hide !
                //exclamationPoint.transform.position = pointOne.position; //move ! to next position

                Debug.Log("touched red, bools redRiddle:" + redRiddle + " orangeRiddle: " + orangeRiddle);
                carrotActive = true;
            }
        } else if(other.gameObject.name == "carrot1" && carrotActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, A CARROT! JUST WHAT I NEEDED!\n\nSEEMS LIKE ORANGE NEEDS SOME HELP TOO.";
                Debug.Log("found carrot");
                carrotSprite.SetActive(false);

                exclamationPoint.SetActive(true); //upon touching egg, show next !
                exclamationPoint.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointOne;

                redRiddle = false;
                carrotActive = false;
                orangeRiddle = true;
            }
        } else if(other.gameObject.name == "orange_0" && orangeRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "A BOX WITHOUT HINGES, LOCK OR KEY, \nYET A GOLDEN TREASURE LIES INSIDE IT.. \nCAN YOU HELP ME FIND THIS?";

                orangeSprite.color = noColor;

                exclamationPoint.SetActive(false); //upon orange interaction, hide the !

                Debug.Log("touched orange");
                eggActive = true;
            }
        } else if(other.gameObject.name == "egg1" && eggActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "CORRECT, AN EGG! THANK YOU!\n\nTALK TO YELLOW NEXT?";
                Debug.Log("found egg");
                eggSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //upon touching carrot, show new !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointFour;

                orangeRiddle = false;
                eggActive = false;
                yellowRiddle = true;
            }
        } else if(other.gameObject.name == "yellow_0" && yellowRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "IT LOOKS GREEN, IT OPENS RED. \nWHAT YOU EAT IS RED BUT \nWHAT YOU SPIT OUT IS BLACK. \nWHAT AM I LOOKING FOR?";

                yellowSprite.color = noColor;
                exclamationPoint2.SetActive(false); //upon talking, hide again
                //exclamationPoint2.transform.position = pointTwo.position; //move to green position

                Debug.Log("touched yellow");
                watermelonActive = true;
            }
        } else if(other.gameObject.name == "watermelon1" && watermelonActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, A SLICE OF WATERMLON! YUM!\n\nPLEASE HELP GREEN AND CALL IT A DAY!";
                Debug.Log("found watermelon");
                watermelonSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //show !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointTwo;
                
                yellowRiddle = false;
                watermelonActive = false;
                greenRiddle = true;
            }
        } else if(other.gameObject.name == "green_0" && greenRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "WHAT I AM LOOKING FOR HAS NO\nBEGINNING, MIDDLE, OR END.";

                greenSprite.color = noColor;
                exclamationPoint2.SetActive(false);

                Debug.Log("touched green");
                donutActive = true;
            }
        } else if(other.gameObject.name == "donut1" && donutActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "INDEED, IT IS A DONUT!\n\nTHANK YOU SO MUCH FOR YOUR HELP! \nIT'S GETTING LATE... YOU SHOULD HEAD HOME NOW.";
                Debug.Log("found donut");
                donutSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //show !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointFive;
                fiveCheck = true;

                greenRiddle = false;
                donutActive = false;
                homeRiddle = true;
            }
        } else if(other.gameObject.name == "homeDoor" && homeRiddle == true){
                fading = true;
                endText.text = "IT HAS BEEN A GOOD DAY.\nYOU REST WELL...";
                Debug.Log("returned home");
                //gameObject.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                homeRiddle = true;
                //SceneManager.LoadScene("levelTwo"); //go to level two
        } 
    } 

     void OnTriggerEnter2D(Collider2D other){ //COLLIDER not COLLISION bc no physics
        if(other.gameObject.name == "pointFiveCheck" && fiveCheck == true){
                
            exclamationPoint2.SetActive(false);
            Debug.Log("touched point five");
        }
    }

    //------------------------STUFF I TESTED FOR COLLIDERS THAT WAS TOO CONFUSING TO CONTINUE------------------------//
    /*oid OnTriggerStay2D(Collider2D other){ //COLLIDER not COLLISION bc no physics
        if(other.gameObject.name == "red_0" && redCanTalk == true){
            redRiddle = true;
            Debug.Log("touching red");
        } else if(other.gameObject.name == "orange_0" && orangeCanTalk == true){
            orangeRiddle = true;
            Debug.Log("touching orange");
        } else if(other.gameObject.name == "yellow_0" && yellowCanTalk == true){
            yellowRiddle = true;
            Debug.Log("touching yellow");
        } else if(other.gameObject.name == "green_0" && greenCanTalk == true){
            greenRiddle = true;
            Debug.Log("touching green");
        } else{
            redRiddle = false;
            orangeRiddle = false;
            yellowRiddle = false;
            greenRiddle = false;
        }

        if(other.gameObject.name == "carrot1" && carrotActive == true){
            carrotPossible = true;
            Debug.Log("touching carrot");
        } else if (other.gameObject.name == "egg1" && eggActive == true){
            eggPossible = true;
            Debug.Log("touching egg");
        }
    }

    void TalkCheck(){
        if(redRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "HELP ME FIND SOMETHING THAT IS \nORANGE AND SOUNDS LIKE PARROT!";

                exclamationPoint.SetActive(false); //upon interaction, hide !
                //exclamationPoint.transform.position = pointOne.position; //move ! to next position

                Debug.Log("talked to red");
                carrotActive = true;
            }
        } else if (orangeRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "A BOX WITHOUT HINGES, LOCK OR KEY, \nYET A GOLDEN TREASURE LIES INSIDE IT.. \nCAN YOU HELP ME FIND THIS?";

                exclamationPoint.SetActive(false); //upon orange interaction, hide the !

                Debug.Log("talked to orange");
                eggActive = true;
            }
        }
    }

    void RiddleCheck(){
        if (carrotPossible == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, A CARROT! JUST WHAT I NEEDED!\n\nSEEMS LIKE ORANGE (BOTTOM LEFT) NEEDS SOME HELP TOO.";
                Debug.Log("found carrot");

                carrotSprite.SetActive(false);

                exclamationPoint.SetActive(true); //upon touching egg, show next !
                exclamationPoint.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointOne;

                redRiddle = false;
                carrotActive = false;
                orangeCanTalk = true;
                redCanTalk = false;
            }
        } else if (eggPossible){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "CORRECT, AN EGG! THANK YOU!\n\nTALK TO YELLOW (BOTTOM RIGHT) NEXT?";
                Debug.Log("found egg");

                eggSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //upon touching carrot, show new !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointFour;

                orangeRiddle = false;
                eggActive = false;
                yellowCanTalk = true;
                orangeCanTalk = false;
            }
        }
    }*/
}

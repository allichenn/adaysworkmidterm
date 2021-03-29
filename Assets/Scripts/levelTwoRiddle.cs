using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelTwoRiddle : MonoBehaviour
{
    
    public Text keyText;
    public Text endText;

    bool redRiddle = true;
    bool orangeRiddle = false;
    bool yellowRiddle = false;
    bool greenRiddle = false;
    bool blueRiddle = false;
    bool indigoRiddle = false;
    bool pinkRiddle = false;
    bool homeRiddle = false;

    bool carrotActive = false;
    bool eggActive = false;
    bool watermelonActive = false;
    bool donutActive = false;
    bool teapotActive = false;
    bool sandwichActive = false;
    bool cornActive = false;
    bool lastPointCheck = false;

    public AudioSource interactSound, pickUpSound;

    public GameObject exclamationPoint, exclamationPoint2;
    public Transform pointOne, pointTwo, pointThree, pointFour, pointFive, pointSix, pointSeven, lastPoint; //three and four are first
    private Transform currentPoint;

    public GameObject carrotSprite, eggSprite, watermelonSprite, donutSprite, cornSprite, teapotSprite, sandwichSprite;
    public SpriteRenderer redSprite, orangeSprite, yellowSprite, greenSprite, blueSprite, indigoSprite, pinkSprite;
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
        blueSprite.color = shadeColor;
        indigoSprite.color = shadeColor;
        pinkSprite.color = shadeColor;
        
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
                alpha += .002f;
            } else {
                SceneManager.LoadScene("levelThree");
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
                keyText.text = "GOOD MORNING!\nTODAY I AM LOOKING FOR SOMETHING THAT\nBEGINS WITH T, ENDS WITH T, AND HAS T IN IT.";

                exclamationPoint.SetActive(false); //upon interaction, hide !
                //exclamationPoint.transform.position = pointOne.position; //move ! to next position

                Debug.Log("touched red");
                teapotActive = true;
            }
        } else if(other.gameObject.name == "teapot1" && teapotActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, THANK YOU!\nI ALWAYS NEED MY DAILY DOSE OF TEA...\n\nANYWAYS, VISIT ORANGE AGAIN?\nTHEY SEEM TO NEED SOME HELP.";
                Debug.Log("found teapot");
                teapotSprite.SetActive(false);

                exclamationPoint.SetActive(true); //upon touching egg, show next !
                exclamationPoint.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointOne;

                redRiddle = false;
                teapotActive = false;
                orangeRiddle = true;
            }
        } else if(other.gameObject.name == "orange_0" && orangeRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "HELLO AGAIN!\nI'D LIKE YOU TO HELP ME FIND A KIND OF NUT\nTHAT IS EMPTY IN THE CENTER AND HAS NO SHELL.";

                orangeSprite.color = noColor;
                exclamationPoint.SetActive(false); //upon orange interaction, hide the !

                Debug.Log("touched orange");
                donutActive = true;
            }
        } else if(other.gameObject.name == "donut1" && donutActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "MMMM YES, A YUMMY DONUT! THANK YOU!\n\nYELLOW WOULD LIKE TO SEE YOU NEXT.";
                Debug.Log("found donut");
                donutSprite.SetActive(false);

                exclamationPoint2.SetActive(false);
                exclamationPoint.SetActive(true); //upon touching carrot, show new !
                exclamationPoint.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointFour;

                orangeRiddle = false;
                donutActive = false;
                yellowRiddle = true;
            }
        } else if(other.gameObject.name == "yellow_0" && yellowRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "YESTERDAY I ATE SOMETHING YUMMY!\nI REMOVED THE OUTSIDE AND COOKED THE INSIDE.\nTHEN I ATE THE OUTSIDE AND THREW AWAY THE INSIDE.\nHELP ME FIND ANOTHER ONE FOR TODAY?";

                yellowSprite.color = noColor;
                exclamationPoint.SetActive(false); //upon talking, hide again
                exclamationPoint.transform.position = pointTwo.position; //move to green position
                currentPoint = pointTwo;

                Debug.Log("touched yellow");
                cornActive = true;
            }
        } else if(other.gameObject.name == "corn1" && cornActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, I LOVE CORN SO MUCH!!\n\nGREEN SEEMS SUPER EXCITED TO SEE YOU AGAIN,\nGO PAY THEM A VISIT?";
                Debug.Log("found corn");
                cornSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //show !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                //currentPoint = pointTwo;
                
                yellowRiddle = false;
                cornActive = false;
                greenRiddle = true;
            }
        } else if(other.gameObject.name == "green_0" && greenRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "HI AGAIN!!\nIT'S GREAT TO SEE YOU, BUT I'M HUNGRY...\nI'M LOOKING FOR WHAT YOU WOULD CALL A WITCH AT A BEACH.";

                greenSprite.color = noColor;
                exclamationPoint2.SetActive(false);

                Debug.Log("touched green");
                sandwichActive = true;
            }
        } else if(other.gameObject.name == "sandwich1" && sandwichActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "PERFECT, THANK YOU SO MUCH!\n\nBLUE IS A LITTLE CONFUSED ABOUT SOMETHING...\nGO FIND OUT WHAT?";
                Debug.Log("found donut");
                sandwichSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //show !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointFive;

                greenRiddle = false;
                sandwichActive = false;
                blueRiddle = true;
            }
        } else if(other.gameObject.name == "blue_0" && blueRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "HELLO...\nTODAY I NEED SOMETHING THAT\nMUST BE BROKEN BEFORE IT IS USED.\nBUT I CAN'T SEEM TO FIND IT ANYWERE!\nHELP?";

                blueSprite.color = noColor;
                exclamationPoint2.SetActive(false);

                Debug.Log("touched blue");
                eggActive = true;
            }
        } else if(other.gameObject.name == "egg1" && eggActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "AH, THAT'S WHERE THE EGG WENT, THANK YOU.\n\nINDIGO IS REALLY UPSET ABOUT SOMETHING...\nPLEASE HELP COMFORT THEM?";
                Debug.Log("found donut");
                eggSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //show !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointSix;

                blueRiddle = false;
                eggActive = false;
                indigoRiddle = true;
            }
        } else if(other.gameObject.name == "indigo_0" && indigoRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "UWAAA I DONT UNDERSTAND!\n\nWITH THIS, I HEARD YOU GO ON RED AND STOP AT GREEN??\nCAN YOU HELP ME FIND IT SO I CAN UNDERSTAND?";

                indigoSprite.color = noColor;
                exclamationPoint2.SetActive(false);

                Debug.Log("touched indigo");
                watermelonActive = true;
            }
        } else if(other.gameObject.name == "watermelon1" && watermelonActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "OH?! IT'S A WATERMELON!!\nHOW CLEVER... THANK YOU.\n\nIT'S GETTING LATE BUT I HEARD PINK IS A BIG FAN,\nHELP THEM BEFORE HEADING HOME?";
                Debug.Log("found watermelon");
                watermelonSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //show !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = pointSeven;

                indigoRiddle = false;
                watermelonActive = false;
                pinkRiddle = true;
            }
        } else if(other.gameObject.name == "pink_0" && pinkRiddle == true){
            if (Input.GetKey(KeyCode.Space)){
                interactSound.Play();
                keyText.text = "HELLO!!\nI'M SO HAPPY I FINALLY MET YOU!!\nCAN YOU PLEASE HELP ME FIND SOMETHING\nTHAT HAS SKIN BUT CAN'T FEEL... \nCAN BE SWEET BUT IS NOT CANDY,\nCAN BE BAKED BUT IS NOT CAKE?";

                pinkSprite.color = noColor;
                exclamationPoint2.SetActive(false);

                Debug.Log("touched pink");
                carrotActive = true;
            }
        } else if(other.gameObject.name == "carrot1" && carrotActive == true){
            if (Input.GetKey(KeyCode.Space)){
                pickUpSound.Play();
                keyText.text = "YES, A CARROT! THANK YOU SO MUCH!\n\nYOU'RE AS GREAT AS EVERYONE SAYS YOU ARE!\n\nOH, I BET YOU ARE VERY TIRED.\nYOU SHOULD HEAD HOME AND REST NOW.";
                Debug.Log("found carrot");
                carrotSprite.SetActive(false);

                exclamationPoint2.SetActive(true); //show !
                exclamationPoint2.transform.position = gameObject.transform.position; //move ! to next position
                currentPoint = lastPoint;
                lastPointCheck = true;

                pinkRiddle = false;
                carrotActive = false;
                homeRiddle = true;
            }
        } else if(other.gameObject.name == "homeDoor" && homeRiddle == true){
                fading = true;
                endText.text = "IT HAS BEEN ANOTHER GOOD DAY.\nBUT YOU START TO FEEL STRANGE...?\nYOU SHRUG IT OFF AND GO TO SLEEP...";
                Debug.Log("returned home");
                //gameObject.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                homeRiddle = true;
                //SceneManager.LoadScene("levelTwo"); //go to level two
        } 
    } 

     void OnTriggerEnter2D(Collider2D other){ //COLLIDER not COLLISION bc no physics
        if(other.gameObject.name == "lastPointCheck" && lastPointCheck == true){
                
            exclamationPoint2.SetActive(false);
            Debug.Log("touched point five");
        }
    }

}

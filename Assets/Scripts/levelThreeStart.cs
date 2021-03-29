using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelThreeStart : MonoBehaviour
{
    
    public Text keyText;
    public Text endText;

    public AudioSource interactSound, pickUpSound;

    public GameObject exclamationPoint;
    private Transform currentPoint;
    public Transform pointOne;

    //black screen stuff//
    public bool fading = false;
    public SpriteRenderer blackScreen, character;
    private Color fadeColor;
    public float alpha = 1;

    public Color invisible, visible;

    float cameraLeft, cameraRight, cameraBottom, cameraTop;
    float cameraDist = 0.5f;

    bool leftHome = false;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = pointOne;
        character.color = visible;
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
                alpha += .001f;
            } else {
                SceneManager.LoadScene("end");
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
    }

     void OnTriggerEnter2D(Collider2D other){ //COLLIDER not COLLISION bc no physics
        if(other.gameObject.name == "lastPointCheck"){
                
            exclamationPoint.SetActive(false);
            Debug.Log("touched last point");
        } 

        /*if (other.gameObject.name == "homeDoor"){
            Debug.Log("in home");
            character.color = invisible;
        }*/
    }

}

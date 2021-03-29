using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rainbowPlayerMove : MonoBehaviour
{
    /*[SerializedField]*/
    public float moveSpeed;
    public Rigidbody2D rb;

    Vector3 movement;

    //inclass stuff is below
    //private bool reachedPos = true;
    //private bool stopMovement = false;
    //private Vector3 nextPos;
    //private bool hitItem = false;

    public float sightDist;
    Animator myAnim;

    public GameObject spriteObject;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = spriteObject.GetComponent<Animator>();
    }

    void Update(){
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, sightDist);
        //Debug.DrawRay(transform.position, movement, Color.red);
        /*if(hit.collider != null){
            //Debug.Log("hit npc");
            if(hit.collider.tag == "red"){
                Debug.Log("hit red");
                exclamationPoint.SetActive(false);
                exclamationPoint.transform.position = pointOne.position;
                hitRed = true;
            } else if(hit.collider.tag == "orange"){
                Debug.Log("hit orange");
                exclamationPoint.SetActive(true);
                exclamationPoint.transform.position = pointTwo.position;
                hitOrange = true;
            } else if(hit.collider.tag == "yellow"){
                Debug.Log("hit yellow");
                exclamationPoint.SetActive(true);
                exclamationPoint.transform.position = pointThree.position;
                hitYellow = true;
            } else if(hit.collider.tag == "green"){
                Debug.Log("hit green");
                hitGreen = true;
            } else {
                hitItem = false;
                hitOrange = false;
                hitYellow = false;
                hitGreen = false;
            }
        }*/


        /*if(Input.GetMouseButtonDown(0)){
            StartMovement();
        }*/

        /*if(!reachedPos){
            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed);
            if(Vector3.Distance(transform.position, nextPos) <= 1f){
                reachedPos = true;
            }
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementInput();
        rb.velocity = movement * moveSpeed;
        CheckKeys();
    }

    /*void StartMovement(){
        nextPos = Input.mousePosition;
        nextPos = Camera.main.ScreenToWorldPoint(nextPos);
        nextPos.z = 0;
        reachedPos = false;
        Debug.Log(nextPos);
    }*/

    void movementInput(){
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector3(mx, my).normalized;

        /*if (mx > 0){ //going right
            myAnim.SetBool("goingSide", true);
        } else if (mx < 0){ //going left
            myAnim.SetBool("goingSide", true);
        } else if (my > 0){ //going up
            myAnim.SetBool("goingUp", true);
        } else if (my < 0){ //going down
            myAnim.SetBool("goingDown", true);
        } else { //going no where

        }*/

        /*if (movement.x > 0.2f || movement.x <= -0.2){
            myAnim.SetBool("goingSide", true);
        } else {
            if (movement.y > 0){
                myAnim.SetBool("goingUp", true);
            } else {
                myAnim.SetBool("goingDown", true);
            }
        }*/
    }

   void CheckKeys(){ //change animator sprites
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){ //go right
            myAnim.SetBool("goingLeft", false);
            myAnim.SetBool("goingUp", false);
            myAnim.SetBool("goingDown", false);
            myAnim.SetBool("goingRight", true);
        } else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){ //go left
            myAnim.SetBool("goingLeft", true);
            myAnim.SetBool("goingUp", false);
            myAnim.SetBool("goingDown", false);
            myAnim.SetBool("goingRight", false);
        } else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){ //go up
            myAnim.SetBool("goingUp", true);
            myAnim.SetBool("goingLeft", false);
            myAnim.SetBool("goingDown", false);
            myAnim.SetBool("goingRight", false);
        } else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){ //go down
            myAnim.SetBool("goingDown", true);
            myAnim.SetBool("goingUp", false);
            myAnim.SetBool("goingLeft", false);
            myAnim.SetBool("goingRight", false);
        } else {
            myAnim.SetBool("goingDown", false);
            myAnim.SetBool("goingLeft", false);
            myAnim.SetBool("goingUp", false);
            myAnim.SetBool("goingRight", false);
        }

        if(Input.GetKey(KeyCode.R)){ //restart
            SceneManager.LoadScene("menu");
        } 

        /*if(Input.GetKey(KeyCode.W)){
            myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
        } */
    }



    
}

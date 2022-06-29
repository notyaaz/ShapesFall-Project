using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Refs
    SpriteRenderer SR;
    
    //Sprites array
    [Header("Sprites")]
    [SerializeField] Sprite square; //fix the bug in the inspetor
    [SerializeField] Sprite circle, traingle, star;

    bool isSquare, isCircle, isTraingle, isStar;

    int n;

    
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

        PlayerSetup();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerUpdate();
    }

    void PlayerSetup()
    {
        SR.sprite = square;

        isSquare = true;
        isCircle = false;
        isTraingle = false;
        isStar = false;

        n = 1;
    }
   
    void PlayerUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            n++;

            if (n == 5) n = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            n--;
            if (n == 0) n = 4;
        }
        
        if (n == 1)
        {
            ResetBools();
            isSquare = true;
        }
        else if (n == 2)
        {
            ResetBools();
            isCircle = true;
        }
        else if (n == 3)
        {
            ResetBools();
            isTraingle = true;
        }
        else if (n == 4)
        {
            ResetBools();
            isStar = true;
        }

        //make bools
        //----------------------------------------------------
        //Update the player

        if(isSquare == true)
        {
            // square mod
            SR.sprite = square;
        }
        else if(isCircle == true)
        {
            // circle mod
            SR.sprite = circle;
        }
        else if (isTraingle == true)
        {
            // traingle mod
            SR.sprite = traingle;
        }
        else if (isStar == true)
        {
            // star mod
            SR.sprite = star;
        }
    }//set bool + set the sprite
    private void OnTriggerEnter2D(Collider2D collision)
    {

            if(isSquare)
            {
                if (collision.CompareTag("Square"))
                {
                    GameManager.instance.HitRight();
                }
                else
                {
                    GameManager.instance.HitWrong();
                }
            }
            //---------------
            else if (isCircle)
            {
                if (collision.CompareTag("Circle"))
                {
                        GameManager.instance.HitRight();
                }
                else
                {
                        GameManager.instance.HitWrong();
                }
            }
            //--------------
            else if (isTraingle)
            {
                if (collision.CompareTag("Traingle"))
                {
                        GameManager.instance.HitRight();
                }
                else
                {
                        GameManager.instance.HitWrong();
                }
            }
            //---------------
            else if (isStar)
            {
                if (collision.CompareTag("Star"))
                {
                        GameManager.instance.HitRight();
                }
                else
                {
                
                        GameManager.instance.HitWrong();
                }
            }
        

        Destroy(collision.gameObject);
    }

    void ResetBools()
    {
        isSquare = false;
        isCircle = false;
        isTraingle = false;
        isStar = false;
    }
}



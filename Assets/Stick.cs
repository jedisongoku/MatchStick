using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stick : MonoBehaviour
{
    public static Stick stick;
    public float turnAngle = -1;
    public SpriteRenderer sprite;
    public List<Sprite> stickSprites = new List<Sprite>();

    public string stickColor;
    public string previousStickColor;

    private int colorRangeMin = 1;
    private float turnAngleBase;
    private int randomNumber;

    void Start()
    {
        stick = this;
        turnAngleBase = turnAngle;
    }

    public void StartStick()
    {
        transform.rotation = Quaternion.identity;
        turnAngle = turnAngleBase;
        colorRangeMin = 1;
        previousStickColor = null;
        SetStickColor();
        StartCoroutine(StartTurning());
    }

    public void SetStickColor()
    {
        previousStickColor = stickColor;
        StartCoroutine(StickColor());
    }

    IEnumerator StickColor()
    {
        
        switch (GameManager.gameManager.selectedLevel)
        {
            case 1:
                randomNumber = Random.Range(colorRangeMin, 3);

                switch (GameManager.gameManager.selectedCircle)
                {
                    case 0:
                        stickColor = ((GameManager.Circle_1_Easy)randomNumber).ToString();
                        break;
                    case 1:
                        stickColor = ((GameManager.Circle_2_Easy)randomNumber).ToString();
                        break;
                    case 2:
                        stickColor = ((GameManager.Circle_3_Easy)randomNumber).ToString();
                        break;
                }
                break;
            case 2:
                randomNumber = Random.Range(colorRangeMin, 4);

                switch (GameManager.gameManager.selectedCircle)
                {
                    case 0:
                        stickColor = ((GameManager.Circle_1_Medium)randomNumber).ToString();
                        break;
                    case 1:
                        stickColor = ((GameManager.Circle_2_Medium)randomNumber).ToString();
                        break;
                    case 2:
                        stickColor = ((GameManager.Circle_3_Medium)randomNumber).ToString();
                        break;
                    case 3:
                        stickColor = ((GameManager.Circle_4_Medium)randomNumber).ToString();
                        break;
                    case 4:
                        stickColor = ((GameManager.Circle_5_Medium)randomNumber).ToString();
                        break;
                }
                break;
            case 3:
                randomNumber = Random.Range(colorRangeMin, 6);

                switch (GameManager.gameManager.selectedCircle)
                {
                    case 0:
                        stickColor = ((GameManager.Circle_1_Hard)randomNumber).ToString();
                        break;
                    case 1:
                        stickColor = ((GameManager.Circle_2_Hard)randomNumber).ToString();
                        break;
                }
                break;
                
        }
        

        yield return new WaitForSeconds(0);

        if (stickColor == previousStickColor)
        {
            StartCoroutine(StickColor());
        }
        else
        {
            Debug.Log(stickColor);
            sprite.sprite = Resources.Load<Sprite>(stickColor);
            colorRangeMin = 0;
        }


    }

    IEnumerator StartTurning()
    {
        if(GameManager.isGameStarted)
        {
            transform.Rotate(0, 0, turnAngle);
        }
        
        yield return new WaitForSeconds(0);

        if(!GameManager.gameOver)
        {
            StartCoroutine(StartTurning());
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.GetComponent<Collision>().GetColor().Equals(stickColor.ToString()))
        {
            GameManager.colorMatch = true;
        }
        else
        {
            if(GameManager.colorMatch)
            {
                GameManager.gameManager.GameOver();
                StopAllCoroutines();
            }
            else
            {
                GameManager.colorMatch = false;
            }
            

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

    }
}

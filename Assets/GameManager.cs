using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;
    public int selectedCircle = 0;
    public enum Circle_1 { DarkPurple, Blue, Red, Yellow };
    public enum Circle_2 { Blue, Red, Green, Purple };
    public enum Circle_3 { Purple, Yellow, Green, LightBlue };
    public enum Circle_4 { Yellow, Green, DarkPurple, Purple };
    public enum Circle_5 { Red, Green, LightBlue, Blue };
    public static bool colorMatch = false;
    public static bool gameOver = false;

    // Use this for initialization
    void Start ()
    {
        gameManager = this;
        StartGame();
    }
	
	public void StartGame ()
    {
        gameOver = false;
        colorMatch = false;
        StartCoroutine(TouchListener());
        Circle.circle.SetCircle();
        Stick.stick.StartStick();
        Player.score = 0;
        GameHUDManager.gameHUDManager.UpdateHUD();

    }

    IEnumerator TouchListener()
    {
        if (!gameOver)
        {
            /*
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(GameManager.colorMatch)
            {
                Stick.stick.SetStickColor();
                Stick.stick.turnAngle *= -1;
            }
        }*/
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("FIRED");
                if (GameManager.colorMatch)
                {
                    colorMatch = false;
                    Stick.stick.SetStickColor();
                    Stick.stick.turnAngle *= -1;
                    if (Stick.stick.turnAngle > 0)
                    {
                        Stick.stick.turnAngle += 0.1f;
                    }
                    Player.score++;
                    if(Player.highScore < Player.score)
                    {
                        Player.highScore = Player.score;
                    }
                    GameHUDManager.gameHUDManager.UpdateHUD();
                }
                else
                {
                    GameOver();
                }
            }
        }

        yield return new WaitForSeconds(0);

        StartCoroutine(TouchListener());
    }

    public void GameOver()
    {
        gameOver = true;
        DataStore.Save();
        GameHUDManager.gameHUDManager.GameOver();
        StopAllCoroutines();
        

    }

    public void Restart()
    {

        StartGame();
    }

}

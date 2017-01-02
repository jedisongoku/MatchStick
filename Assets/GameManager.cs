using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;
    public int selectedCircle = 0;
    public int selectedLevel;
    public int selectedDifficulty = 1;
    public enum Circle_1_Easy { Green, DarkPurple, Blue };
    public enum Circle_2_Easy { Red, Purple, LightBlue };
    public enum Circle_3_Easy { Yellow, Red, Green };
    public enum Circle_1_Medium { DarkPurple, Blue, Red, Yellow };
    public enum Circle_2_Medium { Blue, Red, Green, Purple };
    public enum Circle_3_Medium { Purple, Yellow, Green, LightBlue };
    public enum Circle_4_Medium { Yellow, Green, DarkPurple, Purple };
    public enum Circle_5_Medium { Red, Green, LightBlue, Blue };
    public enum Circle_1_Hard { Yellow, LightBlue, DarkPurple, Blue, Purple, Red };
    public enum Circle_2_Hard { Red, Green, Purple, DarkPurple, Yellow, Blue };
    public static bool colorMatch = false;
    public static bool gameOver = false;
    public static bool isGameStarted = false;
    public static bool isLevelLoaded = false;
    public AudioSource music;

    public GameObject levelObject;
    private bool restart = false;

    // Use this for initialization
    void Start ()
    {
        gameManager = this;
    }
	
	public void StartGame (int level)
    {
        music.Play();
        Player.numberOfTries++;
        gameOver = false;
        colorMatch = false;
        
        Player.score = 0;
        //GameHUDManager.gameHUDManager.UpdateHUD();
        selectedLevel = level;
        if(!restart)
        {
            switch (selectedLevel)
            {
                case 1:
                    levelObject = Instantiate(Resources.Load("GameEasy")) as GameObject;
                    break;
                case 2:
                    levelObject = Instantiate(Resources.Load("GameMedium")) as GameObject;
                    break;
                case 3:
                    levelObject = Instantiate(Resources.Load("GameHard")) as GameObject;
                    break;
            }
        }
        isLevelLoaded = true;
        GameHUDManager.gameHUDManager.UpdateHUD();
        GameHUDManager.gameHUDManager.touchText.gameObject.SetActive(true);
        StartCoroutine(TouchListener());
        Invoke("StartGameDelayed", 0);
    }

    void StartGameDelayed()
    {
        switch (selectedDifficulty)
        {

            case 1:
                levelObject.GetComponentInChildren<Circle>().SetCircle();
                levelObject.GetComponentInChildren<Stick>().StartStick();
                //Circle.circle.SetCircle();
                //Stick.stick.StartStick();
                break;
            case 2:
                levelObject.GetComponentInChildren<Circle>().SetCircle();
                levelObject.GetComponentInChildren<Circle>().StartSpin();
                levelObject.GetComponentInChildren<Stick>().StartStick();
                //Circle.circle.SetCircle();
                //.circle.StartSpin();
                //Stick.stick.StartStick();
                break;
            case 3:
                levelObject.GetComponentInChildren<Circle>().SetCircle();
                levelObject.GetComponentInChildren<Circle>().StartSpin();
                levelObject.GetComponentInChildren<Stick>().StartStick();
                break;
        }
        restart = false;
        
        
    }

    IEnumerator TouchListener()
    {
        if (!gameOver)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("FIRED");
                if(isGameStarted)
                {
                    if (colorMatch)
                    {
                        colorMatch = false;
                        Stick.stick.SetStickColor();
                        if (selectedDifficulty == 1)
                        {
                            Stick.stick.turnAngle *= -1;
                        }
                        else if (selectedDifficulty == 2)
                        {
                            Circle.circle.turnAngle *= -1;
                            Stick.stick.turnAngle *= -1;
                        }
                        else if (selectedDifficulty == 3)
                        {
                            int rand = Random.Range(-100, 100);
                            if (rand < 0)
                            {
                                Circle.circle.turnAngle *= -1;
                            }
                            rand = Random.Range(-100, 100);
                            if (rand < 0)
                            {
                                Stick.stick.turnAngle *= -1;
                            }
                        }
                        if (Stick.stick.turnAngle > 0 && Stick.stick.turnAngle < 4)
                        {
                            Stick.stick.turnAngle += 0.1f;
                        }
                        Player.score++;
                        if (Player.highScores[selectedLevel][selectedDifficulty - 1] < Player.score)
                        {
                            Player.highScores[selectedLevel][selectedDifficulty - 1] = Player.score;
                        }
                        GameHUDManager.gameHUDManager.UpdateHUD();
                    }
                    else
                    {
                        GameOver();
                    }
                }
                if (isLevelLoaded)
                {
                    GameHUDManager.gameHUDManager.touchText.gameObject.SetActive(false);
                    isLevelLoaded = false;
                    isGameStarted = true;
                    //Invoke("StartGameDelayed", 0);
                }

            }
        }

        yield return new WaitForSeconds(0);

        StartCoroutine(TouchListener());
    }

    public void GameOver()
    {
        music.Stop();
        Handheld.Vibrate();
        Player.numberOfTries++;
        gameOver = true;
        if(Player.numberOfTries == 5)
        {
            Player.numberOfTries = 0;
            UnityAds.ads.ShowAd();
        }
        DataStore.Save();
        GameHUDManager.gameHUDManager.GameOver();
        StopAllCoroutines();
        

    }

    public void Restart()
    {
        music.Play();
        restart = true;
        isGameStarted = false;
        isLevelLoaded = true;
        StartGame(selectedLevel);
        
    }

}

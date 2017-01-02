using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using System.Collections;

public class GameHUDManager : MonoBehaviour {

    public static GameHUDManager gameHUDManager;
    public Text score;
    public Text highScore;
    public Transform restartButton;
    public Transform menuButton;
    public Transform menuHUD;
    public Transform gameHUD;
    public Transform touchText;

    [Header("Game Center")]
    private string ios_Level_1_Easy = "level_1_easy";
    private string ios_Level_1_Medium = "level_1_medium";
    private string ios_Level_1_Hard = "level_1_hard";
    private string ios_Level_2_Easy = "level_2_easy";
    private string ios_Level_2_Medium = "level_2_medium";
    private string ios_Level_2_Hard = "level_3_hard";
    private string ios_Level_3_Easy = "level_3_easy";
    private string ios_Level_3_Medium = "level_3_medium";
    private string ios_Level_3_Hard = "level_3_hard";
    private string android_Level_1_Easy = "level_1_easy";
    private string android_Level_1_Medium = "level_1_medium";
    private string android_Level_1_Hard = "level_1_hard";
    private string android_Level_2_Easy = "level_2_easy";
    private string android_Level_2_Medium = "level_2_medium";
    private string android_Level_2_Hard = "level_3_hard";
    private string android_Level_3_Easy = "level_3_easy";
    private string android_Level_3_Medium = "level_3_medium";
    private string android_Level_3_Hard = "level_3_hard";
    private string Level_1_Easy;
    private string Level_1_Medium;
    private string Level_1_Hard;
    private string Level_2_Easy;
    private string Level_2_Medium;
    private string Level_2_Hard;
    private string Level_3_Easy;
    private string Level_3_Medium;
    private string Level_3_Hard;


    void Start()
    {
        gameHUDManager = this;
        DataStore.Load();

        if (Application.platform == RuntimePlatform.Android)
        {
            //PlayGamesPlatform.Activate();
            Level_1_Easy = android_Level_1_Easy;
            Level_1_Medium = android_Level_1_Medium;
            Level_1_Hard = android_Level_1_Hard;
            Level_2_Easy = android_Level_2_Easy;
            Level_2_Medium = android_Level_2_Medium;
            Level_2_Hard = android_Level_2_Hard;
            Level_3_Easy = android_Level_3_Easy;
            Level_3_Medium = android_Level_3_Medium;
            Level_3_Hard = android_Level_3_Hard;

    }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Level_1_Easy = ios_Level_1_Easy;
            Level_1_Medium = ios_Level_1_Medium;
            Level_1_Hard = ios_Level_1_Hard;
            Level_2_Easy = ios_Level_2_Easy;
            Level_2_Medium = ios_Level_2_Medium;
            Level_2_Hard = ios_Level_2_Hard;
            Level_3_Easy = ios_Level_3_Easy;
            Level_3_Medium = ios_Level_3_Medium;
            Level_3_Hard = ios_Level_3_Hard;
        }
        else
        {
            Level_1_Easy = ios_Level_1_Easy;
            Level_1_Medium = ios_Level_1_Medium;
            Level_1_Hard = ios_Level_1_Hard;
            Level_2_Easy = ios_Level_2_Easy;
            Level_2_Medium = ios_Level_2_Medium;
            Level_2_Hard = ios_Level_2_Hard;
            Level_3_Easy = ios_Level_3_Easy;
            Level_3_Medium = ios_Level_3_Medium;
            Level_3_Hard = ios_Level_3_Hard;
        }

        Social.localUser.Authenticate(success => { if (success) { Debug.Log("==iOS GC authenticate OK"); } else { Debug.Log("==iOS GC authenticate Failed"); } });
    }

    public void UpdateHUD()
    {
        score.text = Player.score.ToString();
        highScore.text = Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1].ToString();
        if(GameManager.isGameStarted)
        {
            score.GetComponent<Animator>().SetTrigger("Score");
            if (Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1] == Player.score)
            {
                highScore.GetComponent<Animator>().SetTrigger("Score");
            }
            Stick.stick.GetComponent<Animator>().SetTrigger("Score");
        }
        
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        UpdateHUD();
    }

    public void Restart()
    {
        GameManager.gameManager.Restart();
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
    }

    public void StartGame(int level)
    {
        menuHUD.gameObject.SetActive(false);
        gameHUD.gameObject.SetActive(true);
        GameManager.gameManager.StartGame(level);
    }

    public void GoToMenu()
    {
        Destroy(GameManager.gameManager.levelObject, 0);
        GameManager.isGameStarted = false;
        GameManager.isLevelLoaded = false;
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        menuHUD.gameObject.SetActive(true);
        gameHUD.gameObject.SetActive(false);
    }

    public void SetDifficulty(int difficulty)
    {
        GameManager.gameManager.selectedDifficulty = difficulty;
    }

    void SetLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            switch (GameManager.gameManager.selectedLevel)
            {
                case 1:
                    if (GameManager.gameManager.selectedDifficulty == 1)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_1_Easy, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    else if (GameManager.gameManager.selectedDifficulty == 2)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_1_Medium, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    else if (GameManager.gameManager.selectedDifficulty == 3)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_1_Hard, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    break;
                case 2:
                    if (GameManager.gameManager.selectedDifficulty == 1)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_2_Easy, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    else if (GameManager.gameManager.selectedDifficulty == 2)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_2_Medium, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    else if (GameManager.gameManager.selectedDifficulty == 3)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_2_Hard, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    break;
                case 3:
                    if (GameManager.gameManager.selectedDifficulty == 1)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_3_Easy, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    else if (GameManager.gameManager.selectedDifficulty == 2)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_3_Medium, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    else if (GameManager.gameManager.selectedDifficulty == 3)
                    {
                        Social.ReportScore(Player.highScores[GameManager.gameManager.selectedLevel][GameManager.gameManager.selectedDifficulty - 1], Level_3_Hard, success =>
                        { if (success) { Debug.Log("==iOS GC report score ok:"); } else { Debug.Log("==iOS GC report score Failed:"); } });
                    }
                    break;
            }
        }
        else
        {
            Debug.Log("==iOS GC can't report score, not authenticated\n");
        }
    }

    public void ShowLeaderboard()
    {
        Debug.Log("leaderboard");
        Social.ShowLeaderboardUI();
    }

}

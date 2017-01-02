using UnityEngine;
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

    void Start()
    {
        gameHUDManager = this;
        DataStore.Load();
    }

    public void UpdateHUD()
    {
        score.text = Player.score.ToString();
        highScore.text = Player.highScore.ToString();
        score.GetComponent<Animator>().SetTrigger("Score");
        if(Player.highScore == Player.score)
        {
            highScore.GetComponent<Animator>().SetTrigger("Score");
        }
        Stick.stick.GetComponent<Animator>().SetTrigger("Score");
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
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        menuHUD.gameObject.SetActive(true);
        gameHUD.gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHUDManager : MonoBehaviour {

    public static GameHUDManager gameHUDManager;
    public Text score;
    public Text highScore;
    public Transform restartButton;

    void Start()
    {
        gameHUDManager = this;
        DataStore.Load();
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        score.text = Player.score.ToString();
        highScore.text = Player.highScore.ToString();
        score.GetComponent<Animator>().SetTrigger("Score");
        highScore.GetComponent<Animator>().SetTrigger("Score");
        Stick.stick.GetComponent<Animator>().SetTrigger("Score");
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        UpdateHUD();
    }

    public void Restart()
    {
        GameManager.gameManager.Restart();
        restartButton.gameObject.SetActive(false);
    }
}

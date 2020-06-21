using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button continueBtn;
    [SerializeField] private Button backBtn;

    public void ShowPause()
    {
        text.text = "PAUSE";
        text.color = Color.green;

        continueBtn.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
    }

    public void ShowGameOver()
    {
        text.text = "GAME OVER";
        text.color = Color.red;
        GameController.Instance.CheckHighscore(GameData.CurrentScore);
        continueBtn.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void HidePause()
    {
        this.gameObject.SetActive(false);
    }

    public void CheckPauseOptions()
    {
        GameController.IsGameRunning = !this.gameObject.activeSelf;
        Time.timeScale = GameController.IsGameRunning ? 1 : 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject buttonsPanel;
    [SerializeField] private GameObject howToPlayPanel;
    private Button[] buttons;

    private void OnEnable()
    {
        Time.timeScale = 1;
        if (LevelController.Instance != null)
            LevelController.Instance.Plank.ball.SetPosition(new Vector2(-100,-100));
        buttons = buttonsPanel.GetComponentsInChildren<Button>();
        buttons[0].interactable = false;

        if (GameController.Instance.Save.SaveBlock == null) return;
        if (GameController.Instance.Save.SaveBlock.BlocksOfMap == null) return;

        buttons[0].interactable = true;
    }

    public void OnClickContinue()
    {
        GameController.Instance.LoadGame();
    }

    public void OnClickNewGame()
    {
        GameController.Instance.StartNewGame();
    }

    public void OnClickHowToPlay()
    {
        howToPlayPanel.SetActive(!howToPlayPanel.activeSelf);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}

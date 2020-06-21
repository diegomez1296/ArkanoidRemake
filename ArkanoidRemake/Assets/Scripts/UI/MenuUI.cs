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
        buttons = buttonsPanel.GetComponentsInChildren<Button>();
        buttons[0].interactable = false;

        if (GameController.Instance.Save.SaveBlock == null) return;
        if (GameController.Instance.Save.SaveBlock.BlocksOfMap == null) return;

        buttons[0].interactable = true;
    }

    public void OnClickContinue()
    {

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

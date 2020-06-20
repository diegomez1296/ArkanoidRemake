using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject buttonsPanel;
    private Button[] buttons;

    private void OnEnable()
    {
        buttons = buttonsPanel.GetComponentsInChildren<Button>();
        buttons[0].interactable = false;

        if (GameController.Instance.Save.SaveBlock == null) return;
        if (GameController.Instance.Save.SaveBlock.Map == null) return;

        buttons[0].interactable = true;
    }

    public void OnClickContinue()
    {

    }

    public void OnClickNewGame()
    {

    }

    public void OnClickHowToPlay()
    {

    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}

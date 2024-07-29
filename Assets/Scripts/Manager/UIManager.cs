using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    public GameObject mainmenuUI;
    public GameObject finishUI;
    public TextMeshProUGUI score;
    public TextMeshProUGUI level;
    public TextMeshProUGUI scoreWIN;

    private void Update()
    {
        score.text = CONST.TEXT_SCORE + LevelManager.Instance.GetScore().ToString();
        level.text = CONST.TEXT_LEVEL + LevelManager.Instance.GetLevel().ToString();
    }
    public void OpenMainMenuUI()
    {
        mainmenuUI.SetActive(true);
        finishUI.SetActive(false);
    }
    public void OpenFinishUI()
    {
        mainmenuUI.SetActive(false);
        finishUI.SetActive(true);
        scoreWIN.text = score.text;
    }
    public void ButtonPlay()
    {
        mainmenuUI.SetActive(false);
        LevelManager.Instance.OnStart();

    }
    public void ButtonRePlay()
    {
        LevelManager.Instance.LoadRePlayLevel();
        GameManager.Instance.ChangeState(EGameState.MainMenu);
        OpenMainMenuUI();
    }
    public void ButtonNext()
    {
        LevelManager.Instance.LoadNextLevel();
        GameManager.Instance.ChangeState(EGameState.MainMenu);
        OpenMainMenuUI();
    }

}

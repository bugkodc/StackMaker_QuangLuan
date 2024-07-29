using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public List<Level> levels = new List<Level>();
    public Player player;
    private Level currentLevel;
    private int level;
    private void Start()
    {
        level = 1;
        SetDataLevel(level);
        GameManager.Instance.ChangeState(EGameState.GamePlay);
        LoadLevel(level);
        OnInit();
        UIManager.Instance.OpenMainMenuUI();
    }

    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = Instantiate(levels[level - 1]);
        OnInit();
    }

    public void OnInit()
    {
        player.OnInit();
        player.transform.position = Vector3.zero;
        player.transform.position = currentLevel.startPoint.position + Vector3.up * 3f;
    }
    public void OnStart()
    {
        player.isPlay = true;
    }
    public void OnFinish()
    {
        // luu 
        UIManager.Instance.OpenFinishUI();
        GameManager.Instance.ChangeState(EGameState.Finish);
    }

    public void LoadRePlayLevel() //Choi lai tu man 1
    {
        player.score = 0;
        level = 1;
        SetDataLevel(level);
        LoadLevel(PlayerPrefs.GetInt("level"));
        OnInit();
    }

    public void LoadNextLevel()
    {
        // up level
        level++;
        SetDataLevel(level);
        LoadLevel(PlayerPrefs.GetInt("level"));
        OnInit();
    }

    public float GetScore()
    {
        return player.score;
    }
    public float GetLevel()
    {
        return level;
    }
    private void SetDataLevel(int level)
    {
        PlayerPrefs.SetInt("level", level);
    }
}

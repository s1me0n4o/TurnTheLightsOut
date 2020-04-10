using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action GameStarted;

    public GridManager gridManager;
    public GameObject endScreen;

    public int currentLevel;
    public int numberOfMoves;

    private Dictionary<int, List<int>> _levelSettings;
    private bool _gameHasStarted;

    private void Awake()
    {
        _levelSettings = new Dictionary<int, List<int>>();
        _levelSettings = LevelHandler.LoadLevelData();

        Init(_levelSettings.Count);
    }

    public void Init(int number)
    {
        var progress = 1;
        numberOfMoves = number;
        currentLevel = progress;
        LevelCounterUI.level = currentLevel;
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        if (!_gameHasStarted)
        {
            _levelSettings.TryGetValue(currentLevel, out var allLightsOff);
            gridManager.LoadGrid(allLightsOff);
            _gameHasStarted = true;
            GameStarted();
        }
    }

    public void CurrentLevelEnded()
    {
        SaveScore();
        currentLevel++;
        LevelCounterUI.level = currentLevel;
        numberOfMoves = 0;
        StartCoroutine(FaderUI.Instance.FadeOutIn());

        if (currentLevel <= _levelSettings.Count)
        {
            LoadNextLevel();
        }
        else
        {
            LevelCounterUI.level = _levelSettings.Count;
            endScreen.SetActive(true);
        }
    }

    private void LoadNextLevel()
    {
        _levelSettings.TryGetValue(currentLevel, out var allLightsOff);
        gridManager.SetLevelLights(allLightsOff);
    }

    private void SaveScore()
    {
        var cr = currentLevel.ToString();
        if (PlayerPrefs.HasKey(cr))
        {
            PlayerPrefs.SetInt(cr, numberOfMoves);
        }
    }

    public void IsLevelCompleted()
    {
        for (int i = 1; i <= GridManager.LightsPositions.Count; i++)
        {
            if (GridManager.LightsPositions.TryGetValue(i, out var go))
            {
                if (!go.GetComponent<LightningSwitch>().IsTheLightOff())
                {
                    return;
                }
            }
        }
        CurrentLevelEnded();
    }

}

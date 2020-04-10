using Assets.Levels;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelHandler
{
    //TODO this may need to be changed on Application.persistentDataPath + "/test.json";
    private const string LEVEL_FOLDER = "Assets/Resources/";
    private static Dictionary<int, List<int>> _levelsData;

    public static Dictionary<int, List<int>> LoadLevelData()
    {
        _levelsData = new Dictionary<int, List<int>>();

        DirectoryInfo directoryInfo = new DirectoryInfo(LEVEL_FOLDER);
        FileInfo[] levelsFiles = directoryInfo.GetFiles("Levels.txt");
        FileInfo mostRecentFile = null;
        foreach (var fileInfo in levelsFiles)
        {
            if (mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }

        if (mostRecentFile != null)
        {
            string savedString = File.ReadAllText(mostRecentFile.ToString());
            var levelsSettings = JsonUtility.FromJson<LevelData>(savedString);
            foreach (var level in levelsSettings.Levels)
            {
                if (level.Level == 0 || level.LevelSetup == null)
                {
                    return null;
                }
                ProcessLevelData(level.Level, level.LevelSetup);
            }
            return _levelsData;
        }
        else
        {
            return null;
        }
    }

    private static void ProcessLevelData(int level, string levelSettings)
    {
        var convertedLevelSettings = new List<int>();

        var levelSettingsArray = levelSettings.Split(',');
        foreach (var item in levelSettingsArray)
        {
            convertedLevelSettings.Add(Convert.ToInt32(item));
        }
        _levelsData.Add(level, convertedLevelSettings);
    }
}

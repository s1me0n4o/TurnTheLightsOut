using Assets.Levels;
using UnityEngine;

public class SaveLevels : MonoBehaviour
{
    public GameObject gridManager;
    private int _level = 0;
    private int _incrementLevel = 1;

    public void SaveTheLevel()
    {
        var chields = gridManager.GetComponentsInChildren<LightningSwitch>();
        _level += _incrementLevel;
        string levelSettings = null;
        foreach (var chield in chields)
        {
            if (chield.IsTheLightOff())
            {
                levelSettings = string.Concat(levelSettings, ",", chield.name);
            }
        }

        SaveToEditorFile(_level, levelSettings);
    }

    private void SaveToEditorFile(int level, string levelSettings)
    {
        var path = Application.persistentDataPath + "/Levels.txt";
        var a = new Levels();
        a.Level = level;
        a.LevelSetup = levelSettings;
        string data = JsonUtility.ToJson(a);
        System.IO.File.WriteAllText(path, data);
        Debug.Log(path);
    }
}

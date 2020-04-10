using UnityEngine;
using UnityEngine.UI;

public class LevelCounterUI : MonoBehaviour
{
    public static int level;
    private Text _levelText;

    private void Awake()
    {
        _levelText = GetComponent<Text>();
    }

    private void Update()
    {
        _levelText.text = $"Level: {level.ToString()}";
    }
}

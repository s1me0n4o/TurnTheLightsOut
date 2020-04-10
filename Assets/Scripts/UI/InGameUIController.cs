using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIController : MonoBehaviour
{
    public GameObject settings;
    public GameObject exitButton;
    public GameObject settingsButton;
    public GameObject myMenu;

    public void ShowSettingsPanel()
    {
        settings.SetActive(true);
        settingsButton.SetActive(false);
        exitButton.SetActive(true);
    }

    public void ExitSettingsPanel()
    {
        settings.SetActive(false);
        settingsButton.SetActive(true);
        exitButton.SetActive(false);
    }

    private void LoadMyMenu()
    {
        myMenu.SetActive(true);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

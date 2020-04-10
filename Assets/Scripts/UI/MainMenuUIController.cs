using UnityEngine;

public class MainMenuUIController : MonoBehaviour
{

    public GameObject aboutPage;
    public GameObject inGameUI;
    public GameObject title;
    public GameObject buttons;

    private CanvasGroup _titleCanvasGrp;

    private void Awake()
    {
        aboutPage.SetActive(false);
        _titleCanvasGrp = title.GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        GameManager.GameStarted += OnGameStarted;
    }

    private void OnGameStarted()
    {
        this.gameObject.SetActive(false);
        inGameUI.SetActive(true);
    }

    public void ShowAboutPage()
    {
        _titleCanvasGrp.alpha = 0f;
        aboutPage.SetActive(true);
        buttons.SetActive(false);
    }

    public void CloseAboutPage()
    {
        _titleCanvasGrp.alpha = 1f;
        aboutPage.SetActive(false);
        buttons.SetActive(true);
    }
    private void OnDisable()
    {
        GameManager.GameStarted -= OnGameStarted;

    }
}

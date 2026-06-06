using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button returnMenuButton;
    [SerializeField] private Button quitButton;

    [Header("Loader")]
    [SerializeField] private SceneLoader sceneLoader;

    private void Awake()
    {
        if (playButton != null) playButton.onClick.AddListener(PlayGame);
        if (creditsButton != null) creditsButton.onClick.AddListener(ShowCredits);
        if (returnMenuButton != null) returnMenuButton.onClick.AddListener(ShowMain);
        if (quitButton != null) quitButton.onClick.AddListener(QuitGame);

        if (sceneLoader == null) sceneLoader = FindAnyObjectByType<SceneLoader>();
    }

    public void ShowCredits()
    {
        if (mainPanel != null) mainPanel.SetActive(false);
        if (creditsPanel != null) creditsPanel.SetActive(true);
    }

    public void ShowMain()
    {
        if (mainPanel != null) mainPanel.SetActive(true);
        if (creditsPanel != null) creditsPanel.SetActive(false);
    }

    private void PlayGame()
    {
        if (sceneLoader != null) sceneLoader.LoadLevel();
    }

    private void QuitGame()
    {
        if (sceneLoader != null) sceneLoader.QuitGame();
    }
}
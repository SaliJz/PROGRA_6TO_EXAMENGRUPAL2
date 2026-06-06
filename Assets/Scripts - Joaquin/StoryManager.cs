using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogController dialogController;
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private GameObject choicesPanel;
    [SerializeField] private GameObject combatPanel;
    [SerializeField] private GameObject endingPanel;

    private void Start()
    {
        StartStory();
    }

    public void StartStory()
    {
        ShowStoryUI();

        if (dialogController == null)
        {
            Debug.LogError("DialogController reference is missing in StoryManager.");
            return;
        }

        dialogController.StartDialog();
    }

    public void ShowStoryUI()
    {
        if (storyPanel != null) storyPanel.SetActive(true);
        if (choicesPanel != null) choicesPanel.SetActive(false);
        if (combatPanel != null) combatPanel.SetActive(false);
        if (endingPanel != null) endingPanel.SetActive(false);
    }

    public void ShowChoicesUI()
    {
        if (storyPanel != null) storyPanel.SetActive(false);
        if (choicesPanel != null) choicesPanel.SetActive(true);
        if (combatPanel != null) combatPanel.SetActive(false);
        if (endingPanel != null) endingPanel.SetActive(false);
    }

    public void ShowCombatUI()
    {
        if (storyPanel != null) storyPanel.SetActive(false);
        if (choicesPanel != null) choicesPanel.SetActive(false);
        if (combatPanel != null) combatPanel.SetActive(true);
        if (endingPanel != null) endingPanel.SetActive(false);
    }

    public void ShowEndingUI()
    {
        if (storyPanel != null) storyPanel.SetActive(false);
        if (choicesPanel != null) choicesPanel.SetActive(false);
        if (combatPanel != null) combatPanel.SetActive(false);
        if (endingPanel != null) endingPanel.SetActive(true);
    }
}
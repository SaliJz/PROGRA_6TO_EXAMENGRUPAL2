using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogController dialogController;
    [SerializeField] private GameObject storyCanvas;
    [SerializeField] private GameObject combatCanvas;

    private void Start()
    {
        StartStory();
    }

    public void StartStory()
    {
        if (storyCanvas != null) storyCanvas.SetActive(true);

        if (combatCanvas != null) combatCanvas.SetActive(false);

        if (dialogController == null)
        {
            Debug.LogError("DialogController reference is missing in StoryManager.");
            return;
        }

        dialogController.StartDialog();
    }

    public void ShowStoryUI()
    {
        if (storyCanvas != null) storyCanvas.SetActive(true);

        if (combatCanvas != null) combatCanvas.SetActive(false);
    }

    public void ShowCombatUI()
    {
        if (storyCanvas != null) storyCanvas.SetActive(false);

        if (combatCanvas != null) combatCanvas.SetActive(true);
    }

    public void RestartStory()
    {
        StartStory();
    }
}
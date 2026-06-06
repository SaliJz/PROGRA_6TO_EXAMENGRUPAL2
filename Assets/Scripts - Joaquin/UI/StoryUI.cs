using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private GameObject choicesPanel;
    [SerializeField] private GameObject endingPanel;

    [Header("Text")]
    [SerializeField] private TMP_Text storyText;
    [SerializeField] private TMP_Text endingText;

    [Header("Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;

    [Header("Managers")]
    [SerializeField] private StoryManager storyManager;

    public void ShowText(string textES, string textEN, Action onContinue)
    {
        storyManager.ShowStoryUI();

        storyText.text = textES + "\n\n" + textEN;

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(() => onContinue?.Invoke());
    }

    public void ShowChoices(ChoiceRuntimeNode[] choices, Action<ChoiceRuntimeNode> onChoiceSelected)
    {
        storyManager.ShowChoicesUI();

        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (ChoiceRuntimeNode choice in choices)
        {
            Button buttonInstance = Instantiate(choiceButtonPrefab, choicesContainer);
            TMP_Text buttonText = buttonInstance.GetComponentInChildren<TMP_Text>();
            buttonText.text = choice.labelES + " / " + choice.labelEN;

            buttonInstance.onClick.RemoveAllListeners();
            buttonInstance.onClick.AddListener(() => onChoiceSelected?.Invoke(choice));
        }
    }

    public void ShowEnding(string textES, string textEN)
    {
        storyManager.ShowEndingUI();
        endingText.text = textES + "\n\n" + textEN;
    }

    public void HideAll()
    {
        if (storyPanel != null) storyPanel.SetActive(false);
        if (choicesPanel != null) choicesPanel.SetActive(false);
        if (endingPanel != null) endingPanel.SetActive(false);
    }
}
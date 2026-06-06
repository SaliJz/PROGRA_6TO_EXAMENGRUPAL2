using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject textPanel;
    [SerializeField] private GameObject choicesPanel;
    [SerializeField] private GameObject endingPanel;

    [Header("Text")]
    [SerializeField] private TMP_Text mainText;

    [Header("Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;

    public void ShowText(string textES, string textEN, Action onContinue)
    {
        HideAll();

        textPanel.SetActive(true);
        mainText.text = textES + "\n\n" + textEN;

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(() => onContinue?.Invoke());
    }

    public void ShowChoices(ChoiceRuntimeNode[] choices, Action<ChoiceRuntimeNode> onChoiceSelected)
    {
        HideAll();

        choicesPanel.SetActive(true);

        foreach (Transform child in choicesContainer)
            Destroy(child.gameObject);

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
        HideAll();

        endingPanel.SetActive(true);
        mainText.text = textES + "\n\n" + textEN;
    }

    public void HideAll()
    {
        if (textPanel != null) textPanel.SetActive(false);
        if (choicesPanel != null) choicesPanel.SetActive(false);
        if (endingPanel != null) endingPanel.SetActive(false);
    }
}
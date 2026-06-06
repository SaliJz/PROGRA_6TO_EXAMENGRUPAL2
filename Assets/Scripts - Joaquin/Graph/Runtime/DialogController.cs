using UnityEngine;

public class DialogController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GenericRuntimeGraph dialogGraph;
    [SerializeField] private StoryUI storyUI;
    [SerializeField] private CombatStarter combatStarter;
    [SerializeField] private StoryManager storyManager;

    [Header("State")]
    [SerializeField] private int startNodeIndex = 0;

    private int currentNodeIndex = 0;

    public void StartDialog()
    {
        currentNodeIndex = startNodeIndex;
        ShowCurrentNode();
    }

    private void ShowCurrentNode()
    {
        if (dialogGraph == null || dialogGraph.nodes == null || dialogGraph.nodes.Count == 0)
        {
            Debug.LogError("Dialog graph is missing or empty.");
            return;
        }

        if (currentNodeIndex < 0 || currentNodeIndex >= dialogGraph.nodes.Count)
        {
            Debug.LogError("Current node index is out of range.");
            return;
        }

        GenericRuntimeNode node = dialogGraph.nodes[currentNodeIndex];

        if (node is TextRuntimeNode textNode)
        {
            storyManager?.ShowStoryUI();

            storyUI.ShowText(
                textNode.textES,
                textNode.textEN,
                () => OnContinueFromText(textNode)
            );
            return;
        }

        if (node is CombatRuntimeNode combatNode)
        {
            storyManager?.ShowCombatUI();
            storyUI.HideAll();
            combatStarter.BeginCombat(this, combatNode);
            return;
        }

        if (node is EndingRuntimeNode endingNode)
        {
            storyManager?.ShowStoryUI();
            storyUI.ShowEnding(endingNode.textES, endingNode.textEN);
            return;
        }

        Debug.LogWarning("Unsupported node type found in dialog graph.");
    }

    private void OnContinueFromText(TextRuntimeNode textNode)
    {
        ChoiceRuntimeNode[] choices = dialogGraph.GetChoicesAfter(currentNodeIndex);

        if (choices != null && choices.Length > 0)
        {
            storyUI.ShowChoices(choices, OnChoiceSelected);
            return;
        }

        if (textNode.nextNodeIndex >= 0)
        {
            currentNodeIndex = textNode.nextNodeIndex;
            ShowCurrentNode();
            return;
        }

        Debug.Log("Dialog finished: no choices and no next node.");
        storyUI.HideAll();
    }

    private void OnChoiceSelected(ChoiceRuntimeNode selectedChoice)
    {
        if (selectedChoice == null)
        {
            Debug.LogWarning("Selected choice is null.");
            return;
        }

        currentNodeIndex = selectedChoice.nextNodeIndex;
        ShowCurrentNode();
    }

    public void OnCombatFinished(bool playerWon, CombatRuntimeNode combatNode)
    {
        if (combatNode == null)
        {
            Debug.LogError("Combat node is null.");
            return;
        }

        currentNodeIndex = playerWon ? combatNode.onWinNextIndex : combatNode.onLoseNextIndex;
        ShowCurrentNode();
    }
}
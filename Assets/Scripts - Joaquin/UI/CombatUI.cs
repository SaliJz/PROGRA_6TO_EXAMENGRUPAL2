using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    [SerializeField] private TMP_Text turnText;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button endTurnButton;

    [SerializeField] private TurnManager turnManager;

    private void Start()
    {
        if (attackButton != null)
        {
            attackButton.onClick.AddListener(AttackFirstEnemy);
        }

        if (endTurnButton != null)
        {
            endTurnButton.onClick.AddListener(EndTurn);
        }
    }

    private void Update()
    {
        if (turnManager != null && turnManager.CurrentCharacter != null && turnText != null)
        {
            turnText.text = "Turno de / Turn: " + turnManager.CurrentCharacter.CharacterName;
        }
    }

    private void AttackFirstEnemy()
    {
        if (turnManager == null || turnManager.CurrentCharacter == null) return;

        EnemyCharacter[] enemies = FindObjectsByType<EnemyCharacter>(FindObjectsSortMode.None);

        foreach (EnemyCharacter enemy in enemies)
        {
            if (enemy != null && enemy.CurrentHealth > 0 && enemy.gameObject.activeInHierarchy)
            {
                CombatManager.Instance.Attack(turnManager.CurrentCharacter, enemy);
                break;
            }
        }
    }

    private void EndTurn()
    {
        if (turnManager != null) turnManager.EndCurrentTurn();
    }
}
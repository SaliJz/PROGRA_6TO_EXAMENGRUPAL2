using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatStarter : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private SceneLoader sceneLoader;

    [Header("Scene Characters")]
    [SerializeField] private List<PlayerCharacter> players;
    [SerializeField] private List<EnemyCharacter> enemies;

    private DialogController currentDialogController;
    private CombatRuntimeNode currentCombatNode;
    private bool combatActive = false;

    public void BeginCombat(DialogController dialogController, CombatRuntimeNode combatNode)
    {
        currentDialogController = dialogController;
        currentCombatNode = combatNode;

        foreach (var enemy in enemies)
        {
            if (enemy != null) enemy.gameObject.SetActive(true);
        }

        List<Character> combatants = new List<Character>();
        combatants.AddRange(players.Where(p => p != null && p.CurrentHealth > 0));
        combatants.AddRange(enemies.Where(e => e != null && e.CurrentHealth > 0));

        turnManager.InitializeCombat(combatants);
        combatActive = true;
    }

    private void Update()
    {
        if (!combatActive) return;

        bool allEnemiesDead = enemies.All(e => e == null || e.CurrentHealth <= 0 || !e.gameObject.activeSelf);
        bool allPlayersDead = players.All(p => p == null || p.CurrentHealth <= 0 || !p.gameObject.activeSelf);

        if (allEnemiesDead) EndCombat(true);
        else if (allPlayersDead) EndCombat(false);
    }

    private void EndCombat(bool playerWon)
    {
        combatActive = false;

        if (playerWon)
        {
            if (sceneLoader != null) sceneLoader.LoadVictory();
        }
        else
        {
            if (sceneLoader != null) sceneLoader.LoadDefeat();
        }
    }
}
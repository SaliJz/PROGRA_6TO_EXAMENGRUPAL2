using UnityEngine;
using System.Collections.Generic;

public class CombatStarter : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyObjects;
    [SerializeField] private List<Character> allCombatants;
    [SerializeField] private GameObject combatPanel;
    [SerializeField] private GameObject storyPanel;
    private TurnManager turnManager;

    private void Start()
    {
        turnManager = FindAnyObjectByType<TurnManager>(FindObjectsInactive.Include);
        // Enemigos desactivados al inicio
        foreach (var e in enemyObjects) e.SetActive(false);
    }

    // Llamado por StoryManager al terminar los diálogos
    public void BeginCombat()
    {
        foreach (var e in enemyObjects) e.SetActive(true);
        storyPanel.SetActive(false);
        combatPanel.SetActive(true);
        turnManager.InitializeCombat(allCombatants);
    }

    public void OnCombatVictory()
    {
        foreach (var e in enemyObjects) e.SetActive(false);
        combatPanel.SetActive(false);
        FindAnyObjectByType<ResultPanel>(FindObjectsInactive.Include).ShowVictory();
    }

    public void OnCombatDefeat()
    {
        combatPanel.SetActive(false);
        FindAnyObjectByType<ResultPanel>(FindObjectsInactive.Include).ShowDefeat();
    }
}
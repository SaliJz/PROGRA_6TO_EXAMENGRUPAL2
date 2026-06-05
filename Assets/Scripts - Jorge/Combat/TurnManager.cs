using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public Queue<Character> TurnQueue =
        new Queue<Character>();

    public Character CurrentCharacter;

    public void InitializeCombat(
        List<Character> combatants)
    {
        foreach (Character character in combatants)
        {
            int initiativeRoll =
                DiceRoller.RollD20();

            initiativeRoll +=
                character.Stats.GetModifier("Dexterity");

            character.Initiative =
                initiativeRoll;
        }

        combatants.Sort(
            (a, b) =>
            b.Initiative.CompareTo(a.Initiative));

        foreach (Character character in combatants)
        {
            TurnQueue.Enqueue(character);
        }

        StartNextTurn();
    }

    public void StartNextTurn()
    {
        if (TurnQueue.Count == 0)
            return;

        CurrentCharacter =
            TurnQueue.Dequeue();

        CurrentCharacter.StartTurn();

        Debug.Log(
            "Current Turn: " +
            CurrentCharacter.CharacterName);
    }

    public void EndCurrentTurn()
    {
        CurrentCharacter.EndTurn();

        if (CurrentCharacter.CurrentHealth > 0)
        {
            TurnQueue.Enqueue(CurrentCharacter);
        }

        StartNextTurn();
    }
}

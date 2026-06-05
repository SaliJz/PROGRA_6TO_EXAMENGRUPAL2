using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    [SerializeField]
    private CombatLog combatLog;

    private void Awake()
    {
        Instance = this;
    }

    public void Attack(
        Character attacker,
        Character target)
    {
        int attackRoll =
            DiceRoller.RollD20();

        attackRoll +=
            attacker.Stats.GetModifier("Strength");

        combatLog.AddEntry(
            attacker.CharacterName +
            " rolled " +
            attackRoll);

        if (attackRoll >= target.ArmorClass)
        {
            int damage =
                DiceRoller.RollD8() +
                attacker.Stats.GetModifier("Strength");

            damage = Mathf.Max(1, damage);

            target.TakeDamage(damage);

            combatLog.AddEntry(
                attacker.CharacterName +
                " hit " +
                target.CharacterName +
                " for " +
                damage);
        }
        else
        {
            combatLog.AddEntry(
                attacker.CharacterName +
                " missed");
        }
    }
}
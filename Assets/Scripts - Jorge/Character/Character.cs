using UnityEngine;

public abstract class Character : MonoBehaviour,
    IDamageable,
    ICombatant
{
    [Header("General")]
    public string CharacterName;

    public int PlayerID;

    [Header("Combat")]
    public int MaxHealth = 20;
    public int CurrentHealth = 20;
    public int ArmorClass = 10;
    public int Initiative;

    [Header("Character Stats")]
    [SerializeField]
    private CharacterStats stats = new CharacterStats();

    public CharacterStats Stats => stats;

    protected virtual void Awake()
    {
        CurrentHealth = MaxHealth;

        Stats.Initialize();
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        Debug.Log(
            CharacterName +
            " took " +
            damage +
            " damage.");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void StartTurn()
    {
        Debug.Log(CharacterName + " started turn.");
    }

    public virtual void EndTurn()
    {
        Debug.Log(CharacterName + " ended turn.");
    }

    public abstract void Die();
}
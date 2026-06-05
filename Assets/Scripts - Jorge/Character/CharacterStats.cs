using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    [Header("Base Stats")]

    [SerializeField] private int strength = 10;
    [SerializeField] private int dexterity = 10;
    [SerializeField] private int constitution = 10;
    [SerializeField] private int intelligence = 10;
    [SerializeField] private int wisdom = 10;
    [SerializeField] private int charisma = 10;

    private Dictionary<string, int> stats;

    public void Initialize()
    {
        stats = new Dictionary<string, int>()
        {
            { "Strength", strength },
            { "Dexterity", dexterity },
            { "Constitution", constitution },
            { "Intelligence", intelligence },
            { "Wisdom", wisdom },
            { "Charisma", charisma }
        };
    }

    public int GetStat(string statName)
    {
        if (stats == null)
            Initialize();

        return stats.ContainsKey(statName)
            ? stats[statName]
            : 0;
    }

    public void SetStat(string statName, int value)
    {
        if (stats == null)
            Initialize();

        if (stats.ContainsKey(statName))
        {
            stats[statName] = value;
        }
    }

    public int GetModifier(string statName)
    {
        int value = GetStat(statName);

        return Mathf.FloorToInt((value - 10) / 2f);
    }

    public Dictionary<string, int> GetAllStats()
    {
        if (stats == null)
            Initialize();

        return stats;
    }
}
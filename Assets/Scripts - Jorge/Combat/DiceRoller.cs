using UnityEngine;

public static class DiceRoller
{
    public static int RollD20()
    {
        return Random.Range(1, 21);
    }

    public static int RollD8()
    {
        return Random.Range(1, 9);
    }

    public static int RollD6()
    {
        return Random.Range(1, 7);
    }
}
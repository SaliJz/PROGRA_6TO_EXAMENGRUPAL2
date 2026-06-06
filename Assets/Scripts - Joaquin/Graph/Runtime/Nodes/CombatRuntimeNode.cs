using System;

[Serializable]
public class CombatRuntimeNode : GenericRuntimeNode
{
    public string enemyNameES;
    public string enemyNameEN;
    public int onWinNextIndex;
    public int onLoseNextIndex;
}
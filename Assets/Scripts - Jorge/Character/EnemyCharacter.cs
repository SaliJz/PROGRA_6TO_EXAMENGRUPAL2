using UnityEngine;

public class EnemyCharacter : Character
{
    public override void Die()
    {
        Debug.Log(
            $"{CharacterName} died");
    }
}

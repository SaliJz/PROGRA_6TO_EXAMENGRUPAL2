using UnityEngine;

public class PlayerCharacter : Character
{
    public override void Die()
    {
        Debug.Log(
            $"Player {PlayerID} ({CharacterName}) died");
    }
}
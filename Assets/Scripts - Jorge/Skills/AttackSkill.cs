public class AttackSkill : Skill
{
    public int Damage = 5;

    public override void Execute(
        Character user,
        Character target)
    {
        target.TakeDamage(Damage);
    }
}

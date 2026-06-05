public abstract class Skill
{
    public string SkillName;

    public abstract void Execute(
        Character user,
        Character target);
}

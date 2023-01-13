public class HealAction : Action
{
    private int _health;

    public HealAction(Character character, int health, int duration) : base(character, duration)
    {
        _health = health;
    }

    public override void OnCreated()
    {
        Character.Heal(_health);
    }
}

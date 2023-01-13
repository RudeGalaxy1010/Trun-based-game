public class HealAction : Action
{
    private int _health;

    public HealAction(Character character, int health, int duration) : base(character, duration)
    {
        _health = health;
        IncompitableWith = typeof(PoisonAction);
    }

    protected override void OnApply()
    {
        Character.Heal(_health);
    }
}

using System;

public class HealAction : Action
{
    private int _health;

    public HealAction(Character character, int health, int duration, Type[] cancells) 
        : base(character, duration, cancells)
    {
        _health = health;
    }

    public override void OnCreated()
    {
        Character.Heal(_health);
    }
}

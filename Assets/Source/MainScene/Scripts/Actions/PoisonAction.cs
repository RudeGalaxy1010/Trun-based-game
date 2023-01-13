using System;

public class PoisonAction : Action
{
    private int _damage;

    public PoisonAction(Character character, int damage, int duration, Type[] cancells) 
        : base(character, duration, cancells)
    {
        _damage = damage;
    }

    protected override void OnApply()
    {
        Character.TakeDamage(_damage);
    }
}

using System;

public class TakeDamageAction : Action
{
    private int _damage;

    public TakeDamageAction(Character character, int damage, int duration, Type[] cancells) 
        : base(character, duration, cancells)
    {
        _damage = damage;
    }

    public override void OnCreated()
    {
        Character.TakeDamage(_damage);
    }
}

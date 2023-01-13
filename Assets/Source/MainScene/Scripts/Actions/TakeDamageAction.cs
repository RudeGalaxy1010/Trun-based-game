public class TakeDamageAction : Action
{
    private int _damage;

    public TakeDamageAction(Character character, int damage, int duration) : base(character, duration)
    {
        _damage = damage;
    }

    public override void OnCreated()
    {
        Character.TakeDamage(_damage);
    }
}

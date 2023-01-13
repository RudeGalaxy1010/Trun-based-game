public class TakeDamageAction : Action
{
    private int _damage;

    public TakeDamageAction(Character character, int damage, int duration) : base(character, duration)
    {
        _damage = damage;
    }

    protected override void OnApply()
    {
        Character.TakeDamage(_damage);
    }
}

public class ProtectAction : Action
{
    private int _protection;
    private bool _applied;

    public ProtectAction(Character character, int protection, int duration) : base(character, duration)
    {
        _protection = protection;
        _applied = false;
    }

    protected override void OnApply()
    {
        if (_applied == true)
        {
            return;
        }

        Character.AddProtection(_protection);
        _applied = true;
    }

    protected override void OnExpired()
    {
        Character.RemoveProtection(_protection);
    }
}

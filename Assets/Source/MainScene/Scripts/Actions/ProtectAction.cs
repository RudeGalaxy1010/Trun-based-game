public class ProtectAction : Action
{
    private int _protection;

    public ProtectAction(Character character, int protection, int duration) : base(character, duration)
    {
        _protection = protection;
    }

    public override void OnCreated()
    {
        Character.AddProtection(_protection);
    }

    protected override void OnExpired()
    {
        Character.RemoveProtection(_protection);
    }
}

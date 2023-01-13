public abstract class Action
{
    private int _duration;

    protected Character Character;

    public Action(Character character, int duration)
    {
        _duration = duration;
        Character = character;
    }

    public bool HasExpired => _duration <= 0;

    public void Apply()
    {
        OnApply();
        _duration--;

        if (HasExpired)
        {
            OnExpired();
        }
    }

    protected virtual void OnApply() { }
    protected virtual void OnExpired() { }
}

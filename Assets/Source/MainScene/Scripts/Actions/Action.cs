using System;

public abstract class Action
{
    private int _duration;

    protected Type IncompitableWith;
    protected Character Character;

    public Action(Character character, int duration)
    {
        _duration = duration;
        Character = character;
        OnCreated();
    }

    public bool Expired => _duration <= 0;

    public void Apply()
    {
        OnApply();
        _duration--;

        if (Expired)
        {
            OnExpired();
        }
    }

    protected virtual void OnCreated() { }
    protected virtual void OnApply() { }
    protected virtual void OnExpired() { }
}

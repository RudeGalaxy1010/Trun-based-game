using System;
using System.Collections.Generic;

[Serializable]
public abstract class Action
{
    private int _duration;

    protected Character Character;
    protected Type[] Cancells;

    public Action(Character character, int duration, Type[] cancells)
    {
        _duration = duration;
        Character = character;
        Cancells = cancells;
    }

    public IReadOnlyList<Type> CancellTypes => Cancells;
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

    public virtual void OnCreated() { }
    protected virtual void OnApply() { }
    protected virtual void OnExpired() { }
}

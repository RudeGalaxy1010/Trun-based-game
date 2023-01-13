using System;
using UnityEngine.Events;

public abstract class Action
{
    public event UnityAction<Action> Expired;

    private int _duration;

    protected Type IncompitableWith;
    protected Character Character;

    public Action(Character character, int duration)
    {
        _duration = duration;
        Character = character;
        OnCreated();
    }

    public void Apply()
    {
        OnApply();
        _duration--;

        if (_duration <= 0)
        {
            Expired?.Invoke(this);
        }
    }

    protected virtual void OnCreated() { }
    protected virtual void OnApply() { }
    protected virtual void OnExpired() { }
}

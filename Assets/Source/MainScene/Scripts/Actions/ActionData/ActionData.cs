using System;
using UnityEngine;

public abstract class ActionData : ScriptableObject
{
    public int Duration;
    public Sprite Icon;
    public ActionData[] Cancells;

    public abstract Action CreateActionFor(Character character);
    public abstract Type GetActionType();
}

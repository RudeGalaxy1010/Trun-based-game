using UnityEngine;

public abstract class ActionData : ScriptableObject
{
    public int Duration;

    public abstract Action CreateActionFor(Character character);
}

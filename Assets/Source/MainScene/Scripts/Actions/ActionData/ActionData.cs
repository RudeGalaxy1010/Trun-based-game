using UnityEngine;

public abstract class ActionData : ScriptableObject
{
    public int Duration;
    public Sprite Icon;

    public abstract Action CreateActionFor(Character character);
}

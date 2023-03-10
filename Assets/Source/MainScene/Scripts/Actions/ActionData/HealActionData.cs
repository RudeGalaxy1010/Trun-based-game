using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Actions/HealActionData", fileName = "New HealActionData")]
public class HealActionData : ActionData
{
    public int Health;

    public override Action CreateActionFor(Character character)
    {
        return new HealAction(character, Health, Duration, Cancells.Select(c => c.GetActionType()).ToArray());
    }

    public override Type GetActionType()
    {
        return typeof(HealAction);
    }
}

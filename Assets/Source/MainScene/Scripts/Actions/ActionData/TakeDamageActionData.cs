using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Actions/TakeDamageActionData", fileName = "New TakeDamageActionData")]
public class TakeDamageActionData : ActionData
{
    public int Damage;

    public override Action CreateActionFor(Character character)
    {
        return new TakeDamageAction(character, Damage, Duration, Cancells.Select(c => c.GetType()).ToArray());
    }

    public override Type GetActionType()
    {
        return typeof(TakeDamageAction);
    }
}

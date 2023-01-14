using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Actions/ProtectionActionData", fileName = "New ProtectionActionData")]
public class ProtectionActionData : ActionData
{
    public int Protection;

    public override Action CreateActionFor(Character character)
    {
        return new ProtectAction(character, Protection, Duration, Cancells.Select(c => c.GetType()).ToArray());
    }

    public override Type GetActionType()
    {
        return typeof(ProtectAction);
    }
}

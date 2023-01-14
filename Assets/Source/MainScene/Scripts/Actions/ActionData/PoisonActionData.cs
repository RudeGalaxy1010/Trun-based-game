using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Actions/PoisonActionData", fileName = "New PoisonActionData")]
public class PoisonActionData : ActionData
{
    public int Damage;

    public override Action CreateActionFor(Character character)
    {
        return new PoisonAction(character, Damage, Duration, Cancells.Select(c => c.GetType()).ToArray());
    }

    public override System.Type GetActionType()
    {
        return typeof(PoisonAction);
    }
}

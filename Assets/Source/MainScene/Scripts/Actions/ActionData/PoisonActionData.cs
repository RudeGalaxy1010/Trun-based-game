using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Actions/PoisonActionData", fileName = "New PoisonActionData")]
public class PoisonActionData : ActionData
{
    public int Damage;

    public override Action CreateActionFor(Character character)
    {
        return new PoisonAction(character, Damage, Duration);
    }
}

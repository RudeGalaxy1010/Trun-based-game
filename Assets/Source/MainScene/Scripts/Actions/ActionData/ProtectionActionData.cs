using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Actions/ProtectionActionData", fileName = "New ProtectionActionData")]
public class ProtectionActionData : ActionData
{
    public int Protection;

    public override Action CreateActionFor(Character character)
    {
        return new ProtectAction(character, Protection, Duration);
    }
}

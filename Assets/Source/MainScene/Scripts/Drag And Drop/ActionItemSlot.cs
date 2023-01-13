using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ActionsPerformer), typeof(Character))]
public class ActionItemSlot : MonoBehaviour, IDropHandler
{
    private ActionsPerformer _actionsPerformer;
    private Character _character;

    private void Awake()
    {
        _actionsPerformer = GetComponent<ActionsPerformer>();
        _character = GetComponent<Character>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent(out ActionItem actionItem))
        {
            ApplyActionItem(actionItem);
        }
    }

    public void ApplyActionItem(ActionItem actionItem)
    {
        Action action = actionItem.CreateActionFor(_character);
        _actionsPerformer.AddAction(action);
        actionItem.Use();
    }
}

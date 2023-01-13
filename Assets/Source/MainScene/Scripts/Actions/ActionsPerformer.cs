using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionsPerformer : MonoBehaviour
{
    [SerializeField] private Field _field;

    private List<Action> _actions = new List<Action>();

    private void OnEnable()
    {
        _field.TurnCompleted += OnTurnComplete;
    }

    private void OnDisable()
    {
        _field.TurnCompleted -= OnTurnComplete;
    }

    public void AddAction(Action action)
    {
        _actions.Add(action);
        ApplyAction(action);
    }

    private void OnTurnComplete()
    {
        ApplyActions();
    }

    private void ApplyActions()
    {
        for (int i = 0; i < _actions.Count; i++)
        {
            ApplyAction(_actions[i]);
        }
    }

    private void ApplyAction(Action action)
    {
        action.Apply();
        _actions = _actions.Where(a => a.Expired == false).ToList();
    }
}

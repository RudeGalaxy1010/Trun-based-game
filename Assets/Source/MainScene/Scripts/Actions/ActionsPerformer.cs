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
        action.Apply();
    }

    private void OnTurnComplete()
    {
        ApplyActions();
    }

    private void ApplyActions()
    {
        for (int i = 0; i < _actions.Count; i++)
        {
            _actions[i].Apply();
        }

        _actions = _actions.Where(a => a.Expired == false).ToList();
    }
}

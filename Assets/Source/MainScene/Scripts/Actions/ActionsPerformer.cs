using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ActionsPerformer : MonoBehaviour
{
    public event UnityAction<Action> ActionAdded;
    public event UnityAction<Action> ActionRemoved;

    [SerializeField] private Field _field;

    private List<Action> _actions = new List<Action>();

    public bool HasAction(Type type) => _actions.FirstOrDefault(a => a.GetType() == type) != null;

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
        ActionAdded?.Invoke(action);
        action.OnCreated();
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

        Action[] expiredActions = _actions.Where(a => a.HasExpired == true).ToArray();

        for (int i = 0; i < expiredActions.Length; i++)
        {
            _actions.Remove(expiredActions[i]);
            ActionRemoved?.Invoke(expiredActions[i]);
        }
    }
}

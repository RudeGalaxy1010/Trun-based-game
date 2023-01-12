using UnityEngine;
using UnityEngine.Events;

public class Field : MonoBehaviour
{
    public event UnityAction<Command> CommandSwitched;

    private const int StartCommandIndex = 0;

    [SerializeField] private Command[] _commands;

    private int _currentCommandIndex;

    private void OnEnable()
    {
        foreach (var command in _commands)
        {
            command.TurnCompleted += OnTurnCompleted;
        }
    }

    private void OnDisable()
    {
        foreach (var command in _commands)
        {
            command.TurnCompleted -= OnTurnCompleted;
        }
    }

    private void Start()
    {
        _currentCommandIndex = StartCommandIndex;
        CommandSwitched?.Invoke(CurrentCommand);
        MakeTurn();
    }

    private Command CurrentCommand => _commands[_currentCommandIndex];

    private void MakeTurn()
    {
        CurrentCommand.MakeTurn();
    }

    private void OnTurnCompleted(Command command)
    {
        SwitchNextCommand();
        MakeTurn();
    }

    private void SwitchNextCommand()
    {
        _currentCommandIndex = (_currentCommandIndex + 1) % _commands.Length;
        CommandSwitched?.Invoke(CurrentCommand);
    }
}

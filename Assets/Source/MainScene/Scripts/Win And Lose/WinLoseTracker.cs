using UnityEngine;
using UnityEngine.Events;

public class WinLoseTracker : MonoBehaviour
{
    public event UnityAction CommandLose;

    [SerializeField] private Command _command;

    private void OnEnable()
    {
        _command.CharactersCountChanged += OnCharactersCountChanged;
    }

    private void OnDisable()
    {
        _command.CharactersCountChanged -= OnCharactersCountChanged;
    }

    private void OnCharactersCountChanged(int charactersCount)
    {
        if (charactersCount == 0)
        {
            CommandLose?.Invoke();
        }
    }
}

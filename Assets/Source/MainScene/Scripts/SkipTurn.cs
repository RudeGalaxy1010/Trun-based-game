using UnityEngine;

public class SkipTurn : MonoBehaviour
{
    private const KeyCode SkipKey = KeyCode.Space;

    [SerializeField] private Field _field;
    [SerializeField] private PlayerCommand _command;
    [SerializeField] private WinLoseTracker[] _winLoseTrackers;

    private bool _canSkip;

    private void OnEnable()
    {
        _field.CommandSwitched += OnCommandSwitched;

        for (int i = 0; i < _winLoseTrackers.Length; i++)
        {
            _winLoseTrackers[i].CommandLose += OnCommandLose;
        }
    }

    private void OnDisable()
    {
        _field.CommandSwitched -= OnCommandSwitched;

        for (int i = 0; i < _winLoseTrackers.Length; i++)
        {
            _winLoseTrackers[i].CommandLose -= OnCommandLose;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(SkipKey))
        {
            TrySkipTurn();
        }
    }

    private void OnCommandLose()
    {
        enabled = false;
    }

    private void OnCommandSwitched(Command command)
    {
        if (_command == command)
        {
            _canSkip = true;
            return;
        }

        _canSkip = false;
    }

    private void TrySkipTurn()
    {
        if (_canSkip == true)
        {
            _command.CompleteTurn();
        }
    }
}

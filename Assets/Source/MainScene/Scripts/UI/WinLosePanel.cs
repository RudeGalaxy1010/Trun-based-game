using UnityEngine;

public class WinLosePanel : MonoBehaviour
{
    [SerializeField] private WinLoseTracker _commandWinLoseTracker;
    [SerializeField] private GameObject _panel;

    private void OnEnable()
    {
        _commandWinLoseTracker.CommandLose += OnCommandLose;
    }

    private void OnDisable()
    {
        _commandWinLoseTracker.CommandLose -= OnCommandLose;
    }

    private void OnCommandLose()
    {
        _panel.SetActive(true);
    }
}

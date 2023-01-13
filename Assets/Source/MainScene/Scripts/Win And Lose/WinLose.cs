using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField] private WinLoseTracker[] _winLoseTrackers;

    private void OnEnable()
    {
        for (int i = 0; i < _winLoseTrackers.Length; i++)
        {
            _winLoseTrackers[i].CommandLose += OnCommandLose;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _winLoseTrackers.Length; i++)
        {
            _winLoseTrackers[i].CommandLose -= OnCommandLose;
        }
    }

    private void OnCommandLose()
    {
        for (int i = 0; i < _winLoseTrackers.Length; i++)
        {
            _winLoseTrackers[i].enabled = false;
        }
    }
}

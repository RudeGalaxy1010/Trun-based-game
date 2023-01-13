using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private const KeyCode RestartKey = KeyCode.R;

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
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(RestartKey))
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

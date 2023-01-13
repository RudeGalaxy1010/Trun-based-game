using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private const KeyCode RestartKey = KeyCode.R;

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

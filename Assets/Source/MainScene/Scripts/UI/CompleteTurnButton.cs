using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CompleteTurnButton : MonoBehaviour
{
    [SerializeField] private Field _field;
    [SerializeField] private PlayerCommand _command;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _field.CommandSwitched += OnCommandSwitched;
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _field.CommandSwitched -= OnCommandSwitched;
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnCommandSwitched(Command command)
    {
        bool isPlayerCommand = command == _command;
        _button.interactable = isPlayerCommand;
    }

    protected void OnButtonClicked()
    {
        _command.CompleteTurn();
    }
}

using UnityEngine;

public class PlayerCommand : Command
{
    private const int StartCharacterIndex = 0;

    [SerializeField] private ActionsPool _actionsPool;

    private int _currentCharacterIndex;

    private bool IsLastCharacterProcessed => _currentCharacterIndex == Characters.Length;
    private Character CurrentCharacter => Characters[_currentCharacterIndex];

    public override void MakeTurn()
    {
        _currentCharacterIndex = StartCharacterIndex;
        CreateAction();
    }

    private void CreateAction()
    {
        ActionItem item = _actionsPool.GetRandomActionItemFor(CurrentCharacter);
        item.Used += OnActionUsed;
    }

    private void OnActionUsed(ActionItem item)
    {
        item.Used -= OnActionUsed;
        _actionsPool.ReturnItem(item);
        _currentCharacterIndex++;

        if (IsLastCharacterProcessed == false)
        {
            CreateAction();
        }
    }
}

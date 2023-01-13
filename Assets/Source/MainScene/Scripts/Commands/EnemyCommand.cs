using System.Collections;
using UnityEngine;

public class EnemyCommand : Command
{
    [SerializeField] private Command _playerCommand;
    [SerializeField] private float _turnDelayTime;

    public override void MakeTurn()
    {
        CurrentCharacterIndex = StartCharacterIndex;
        CreateAction();
    }

    private void CreateAction()
    {
        ActionItem item = ActionsPool.GetRandomActionItemFor(CurrentCharacter);
        ActionItems.Add(item);
        item.enabled = false;
        item.Used += OnActionUsed;
        StartCoroutine(ApplyActionToRandomPlayerCharacter(item));
    }

    private void OnActionUsed(ActionItem item)
    {
        item.Used -= OnActionUsed;
        ActionsPool.ReturnItem(item);
        CurrentCharacterIndex++;

        if (IsLastCharacterProcessed == false)
        {
            CreateAction();
            return;
        }

        CompleteTurn();
    }

    private IEnumerator ApplyActionToRandomPlayerCharacter(ActionItem actionItem)
    {
        Character playerCharacter = _playerCommand.RandomCharacter;
        actionItem.GetComponent<RectTransform>().anchoredPosition = 
            playerCharacter.GetComponent<RectTransform>().anchoredPosition;
        playerCharacter.GetComponent<ActionItemSlot>().ApplyActionItem(actionItem);
        yield return new WaitForSeconds(_turnDelayTime / Characters.Count);
    }
}

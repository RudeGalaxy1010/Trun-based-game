using System.Collections;
using UnityEngine;

public class EnemyCommand : Command
{
    [SerializeField] private Character[] _playerCharacters;
    [SerializeField] private float _turnDelayTime;

    public override void MakeTurn()
    {
        CurrentCharacterIndex = StartCharacterIndex;
        CreateAction();
    }

    private void CreateAction()
    {
        ActionItem item = ActionsPool.GetRandomActionItemFor(CurrentCharacter);
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
        Character playerCharacter = _playerCharacters[Random.Range(0, _playerCharacters.Length)];
        actionItem.GetComponent<RectTransform>().anchoredPosition = 
            playerCharacter.GetComponent<RectTransform>().anchoredPosition;
        playerCharacter.GetComponent<ActionItemSlot>().ApplyActionItem(actionItem);
        yield return new WaitForSeconds(_turnDelayTime / Characters.Length);
    }
}

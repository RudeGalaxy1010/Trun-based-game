public class PlayerCommand : Command
{
    public override void MakeTurn()
    {
        CurrentCharacterIndex = StartCharacterIndex;
        CreateAction();
    }

    private void CreateAction()
    {
        ActionItem item = ActionsPool.GetRandomActionItemFor(CurrentCharacter);
        item.Used += OnActionUsed;
    }

    private void OnActionUsed(ActionItem item)
    {
        item.Used -= OnActionUsed;
        ActionsPool.ReturnItem(item);
        CurrentCharacterIndex++;

        if (IsLastCharacterProcessed == false)
        {
            CreateAction();
        }
    }
}

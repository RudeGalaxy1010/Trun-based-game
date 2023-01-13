public class PlayerCommand : Command
{
    public override void MakeTurn()
    {
        if (Characters.Count == 0)
        {
            return;
        }

        CurrentCharacterIndex = StartCharacterIndex;
        CreateAction();
    }

    private void CreateAction()
    {
        ActionItem item = ActionsPool.GetRandomActionItemFor(CurrentCharacter);
        ActionItems.Add(item);
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

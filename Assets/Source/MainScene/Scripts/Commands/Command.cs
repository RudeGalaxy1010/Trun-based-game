using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Command : MonoBehaviour
{
    protected const int StartCharacterIndex = 0;

    public event UnityAction<Command> TurnCompleted;

    [SerializeField] protected List<Character> Characters;
    [SerializeField] protected ActionsPool ActionsPool;

    protected int CurrentCharacterIndex;
    protected List<ActionItem> ActionItems = new List<ActionItem>();

    public Character RandomCharacter => Characters[Random.Range(0, Characters.Count)];
    protected bool IsLastCharacterProcessed => CurrentCharacterIndex == Characters.Count;
    protected Character CurrentCharacter => Characters[CurrentCharacterIndex];

    private void OnEnable()
    {
        for (int i = 0; i < Characters.Count; i++)
        {
            Characters[i].Died += OnCharacterDied;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < Characters.Count; i++)
        {
            Characters[i].Died -= OnCharacterDied;
        }
    }

    public virtual void CompleteTurn()
    {
        for (int i = 0; i < ActionItems.Count; i++)
        {
            ActionsPool.ReturnItem(ActionItems[i]);
        }

        ActionItems.Clear();
        TurnCompleted?.Invoke(this);
    }

    public abstract void MakeTurn();

    private void OnCharacterDied(Character character)
    {
        character.Died -= OnCharacterDied;
        Characters.Remove(character);
    }
}

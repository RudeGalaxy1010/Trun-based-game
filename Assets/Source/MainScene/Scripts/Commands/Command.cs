using UnityEngine;
using UnityEngine.Events;

public abstract class Command : MonoBehaviour
{
    protected const int StartCharacterIndex = 0;

    public event UnityAction<Command> TurnCompleted;

    [SerializeField] protected Character[] Characters;
    [SerializeField] protected ActionsPool ActionsPool;

    protected int CurrentCharacterIndex;

    protected bool IsLastCharacterProcessed => CurrentCharacterIndex == Characters.Length;
    protected Character CurrentCharacter => Characters[CurrentCharacterIndex];

    public virtual void CompleteTurn()
    {
        TurnCompleted?.Invoke(this);
    }

    public abstract void MakeTurn();
}

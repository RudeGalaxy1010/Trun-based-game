using UnityEngine;
using UnityEngine.Events;

public abstract class Command : MonoBehaviour
{
    public event UnityAction<Command> TurnCompleted;

    [SerializeField] protected Character[] Characters;

    public virtual void CompleteTurn()
    {
        TurnCompleted?.Invoke(this);
    }

    public abstract void MakeTurn();
}

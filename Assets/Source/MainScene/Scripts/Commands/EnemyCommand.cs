using System.Collections;
using UnityEngine;

public class EnemyCommand : Command
{
    [SerializeField] private float _turnDelayTime;

    public override void MakeTurn()
    {
        // TODO: apply actions
        StartCoroutine(CompleteApplyActions());
    }

    private IEnumerator CompleteApplyActions()
    {
        yield return new WaitForSeconds(_turnDelayTime);
        CompleteTurn();
    }
}

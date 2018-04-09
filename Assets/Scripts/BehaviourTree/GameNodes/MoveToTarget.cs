﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : BehaviourNode
{
    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        var mover = context.unit.GetComponent<UnitMover>();
        mover.agent.isStopped = false;
        if (mover.agent.destination == Vector3.zero)
        {
            yield break;
        }
        while (true)
        {
            if (mover.agent.remainingDistance <= mover.agent.stoppingDistance)
            {
                yield break;
            }
            yield return BehaviourStatus.Running;
        }
    }
}

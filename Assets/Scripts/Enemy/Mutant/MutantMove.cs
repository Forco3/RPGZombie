using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantMove : EnemyMove
{
    public float minDistancePunchAttackTarget = 2;
    public float minDistanceJumpAttackTarget = 4;

    public bool isMinDistancePunchAttack = false;
    public bool isMinDistanceJumpAttack = false;

    private void FixedUpdate()
    {
        if (isMinDistanceDefaultAttack || isMinDistancePunchAttack || isMinDistanceJumpAttack) return;
        LookTarget();
        FollowTarget();
    }
    private void Update()
    {
        isMinDistancePunchAttack = IsMinDistance(minDistancePunchAttackTarget);
        isMinDistanceJumpAttack = IsMinDistance(minDistanceJumpAttackTarget);
    }
    public override void LookTarget()
    {
        base.LookTarget();
    }
    public override void FollowTarget()
    {
        base.FollowTarget();
    }
    public override bool IsMinDistance(float minDistance)
    {
        return base.IsMinDistance(minDistance);
    }
}

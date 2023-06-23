using _Main.Scripts.Entities.Enemies.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyData : EnemyData
{
    [field: SerializeField] public float SeekRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float RegularAttackHealthThreshold { get; private set; }
    [field: SerializeField] public float EnhancedAttackHealthThreshold { get; private set; }
    [field: SerializeField] public float SummoningAttackHealthThreshold { get; private set; }
    [field: SerializeField] public float DesperationAttackHealthThreshold { get; private set; }
    [field: SerializeField] public bool IsInvulnerable { get; private set; }
    [field: SerializeField] public bool CanSummon { get; private set; }
    [field: SerializeField] public float AttackStateTimer { get; private set; }
    [field: SerializeField] public float BlockStateTimer { get; private set; }
    //TODO setear en estados cooldown interno (O podríamos ponerlo acá).

}

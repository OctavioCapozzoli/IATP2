using _Main.Scripts.FSM_SO_VERSION;
using UnityEngine;

namespace _Main.Scripts.Entities.Enemies.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "_main/Data/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public StateData[] FsmStates { get; private set; }
        [field: SerializeField] public float RestPatrolTime { get; private set; }
        [field: SerializeField] public float MaxLife { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float SightRange { get; private set; }
        [field: SerializeField] public float TotalSightDegrees { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float DistanceToAttack { get; private set; }
        [field: SerializeField] public float CooldownToAttack { get; private set; }
        [field: SerializeField] public float TimeForSearchPlayer { get; private set; }
        [field: SerializeField] public LayerMask TargetLayer { get; private set; }
        [field: SerializeField] public float FleeHealthValue { get; set; }
        [field: SerializeField] public float IdleTimer { get; set; }
    }
}
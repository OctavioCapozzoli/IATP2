using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "CanAttack", menuName = "_main/Conditions/EnemyConditions/CanAttack")]
    public class CanAttack : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            var enemyModel = (EnemyModel)model;
            var distanceToTarget =
                Vector3.Distance(enemyModel.GetTarget().transform.position, model.transform.position);
            return (distanceToTarget < enemyModel.GetData().DistanceToAttack) && enemyModel.cooldownAttack < 0;
        }
    }
}
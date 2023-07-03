using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "CanAttack", menuName = "_main/Conditions/Enemy Conditions/CanAttack")]
    public class CanAttack : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            var enemyModel = model as EnemyModel;
            //enemyModel.IsAttacking = Vector3.Distance(enemyModel.GetTarget().transform.position, enemyModel.transform.position) < enemyModel.GetData().DistanceToAttack ? true : false;
            return Vector3.Distance(enemyModel.GetTarget().transform.position, enemyModel.transform.position) < enemyModel.GetData().DistanceToAttack;
        }
    }
}
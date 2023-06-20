using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "CanAttack", menuName = "_main/Conditions/Enemy Conditions/CanAttack")]
    public class CanAttack : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            var enemyModel = (EnemyModel)model;
            var distanceToTarget =
                Vector3.Distance(enemyModel.GetTarget().transform.position, model.transform.position);
            Debug.Log("Chequeando attack");
            return distanceToTarget < enemyModel.GetData().DistanceToAttack; //TODO chequear cooldown attack enemy
        }
    }
}
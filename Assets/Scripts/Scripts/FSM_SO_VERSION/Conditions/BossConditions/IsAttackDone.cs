using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.BossConditions
{
    [CreateAssetMenu(fileName = "Is Attack Done?", menuName = "_main/Conditions/Boss Conditions/Is Attack Done?")]
    public class IsAttackDone : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            //TODO manejar este boolean desde afuera, con un triggerenter en el mapa.
            BossEnemyModel bossModel = model as BossEnemyModel;
            return bossModel.GetData().IsAttackDone;

        }
    }
}

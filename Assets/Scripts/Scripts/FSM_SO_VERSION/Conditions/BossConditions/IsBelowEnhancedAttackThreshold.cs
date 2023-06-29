using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.BossConditions
{
    [CreateAssetMenu(fileName = "Is Health Below Enh Attack Threshold?", menuName = "_main/Conditions/Boss Conditions/Is Health Below Enh Attack Threshold?")]
    public class IsBelowEnhancedAttackThreshold : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            BossEnemyModel bossModel = model as BossEnemyModel;

            return bossModel.HealthController.CurrentHealth < bossModel.GetData().EnhancedAttackHealthThreshold;
        }
    }
}
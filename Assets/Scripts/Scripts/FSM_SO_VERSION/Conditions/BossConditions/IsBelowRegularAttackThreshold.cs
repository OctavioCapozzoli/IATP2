using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.BossConditions
{
    [CreateAssetMenu(fileName = "Is Health Below Reg Attack Threshold?", menuName = "_main/Conditions/Boss Conditions/Is Health Below Reg Attack Threshold?")]
    public class IsBelowRegularAttackThreshold : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            BossEnemyModel bossModel = model as BossEnemyModel;
            Debug.Log("is below regular attack threshold? " + (bossModel.HealthController.CurrentHealth <= bossModel.GetData().RegularAttackHealthThreshold));
            return bossModel.HealthController.CurrentHealth <= bossModel.GetData().RegularAttackHealthThreshold;
        }
    }
}

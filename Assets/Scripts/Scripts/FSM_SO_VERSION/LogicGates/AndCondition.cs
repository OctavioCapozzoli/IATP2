using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.LogicGates
{
    [CreateAssetMenu(fileName = "AndCondition", menuName = "_main/Conditions/Logic/AND")]
    public class AndCondition : StateCondition
    {
        [SerializeField] private StateCondition conditionOne;
        [SerializeField] private StateCondition conditionTwo;
        
        public override bool CompleteCondition(EntityModel model)
        {
            Debug.Log("Boss state para pasar a block" + conditionOne.CompleteCondition(model) + conditionTwo.CompleteCondition(model));
            return conditionOne.CompleteCondition(model) && conditionTwo.CompleteCondition(model);
        }
    }
}
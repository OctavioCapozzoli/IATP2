using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{

    public enum PlayerAttackComboState { NONE, PUNCH_1, PUNCH_2, PUNCH_3 }

    [CreateAssetMenu(fileName = "RegularAttackState", menuName = "_main/States/PlayerStates/RegularAttackState", order = 0)]

    public class AttackStatePlayer : State
    {
        PlayerModel playerModel;
        float initComboCooldownTimer = 1f;

        bool isComboReset;
        PlayerAttackComboState currentComboState;

        float currentComboCooldownTimer;

        public override void EnterState(EntityModel model)
        {
            playerModel = model as PlayerModel;
            currentComboCooldownTimer = initComboCooldownTimer;
            currentComboState = PlayerAttackComboState.NONE;
            playerModel.View.PlayerComboAttack1();

        }

        public override void ExecuteState(EntityModel model)
        {
            currentComboCooldownTimer -= Time.deltaTime;
            currentComboState++;
            //if (currentComboCooldownTimer > 0 && currentComboCooldownTimer <= initComboCooldownTimer)
            if (Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("H key pressed");
                if (currentComboState == PlayerAttackComboState.PUNCH_1)
                {
                    playerModel.View.PlayerComboAttack1();
                }
                else if (currentComboState == PlayerAttackComboState.PUNCH_2)
                {
                    playerModel.View.PlayerComboAttack2();
                }
                else if (currentComboState == PlayerAttackComboState.PUNCH_3)
                {
                    playerModel.View.PlayerComboAttack3();
                }
            }
            //}
            //else
            //{
            //model.IsAttacking = false;
            //model.IsIdle = true;
            //}
            //ResetComboState();
            //else if (!Input.GetKeyDown(KeyCode.J) && currentComboCooldown <= 0f)
            //    ResetComboState();

        }
        public override void ExitState(EntityModel model)
        {
        }

        void ComboAttacks()
        {

            //if (currentComboState == PlayerAttackComboState.PUNCH_3) return;

            Debug.Log("Combo state" + currentComboState);


        }
        void ResetComboState()
        {
            if (isComboReset)
            {
                //Debug.Log("Reset entered");
                currentComboCooldownTimer -= Time.deltaTime;

                if (currentComboCooldownTimer <= 0f)
                {

                    currentComboState = PlayerAttackComboState.NONE;

                    isComboReset = false;
                    currentComboCooldownTimer = initComboCooldownTimer;

                }
            }
        }

    }
}
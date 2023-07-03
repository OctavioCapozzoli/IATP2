using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{

    public enum PlayerAttackComboState { NONE, PUNCH_1, PUNCH_2, PUNCH_3 }

    [CreateAssetMenu(fileName = "Regular Attack State", menuName = "_main/States/Player States/Regular Attack State", order = 0)]

    public class AttackStatePlayer : State
    {
        PlayerModel playerModel;
        PlayerAttackComboState playerCurrentState;
        float maxComboTimer = .5f;
        float currentComboTimer = 0;

        public override void EnterState(EntityModel model)
        {
            Debug.Log("Enter");
            playerModel = model as PlayerModel;
            playerModel.LineOfSight();
            if(playerModel.IsSeeingTarget && playerModel.IsAttacking)
            {
                if(playerModel.Target != null)
                {
                    Debug.Log("Target is in sight, executing look dir");
                    Vector3 dir = playerModel.Target.position - playerModel.transform.position;
                    playerModel.LookDir(dir);
                }
            }
            CheckComboAnim();
            ResetCombo();
        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Attack State Player Execute");
            //playerModel.LineOfSight(); //lookdir
            Debug.Log("Target in sight in attack state execute: " + playerModel.IsSeeingTarget + playerModel.LineOfSight());
            currentComboTimer -= Time.deltaTime;
            if (currentComboTimer > 0)
            {
                Debug.Log("entra en combo timer" + playerModel.IsAttacking);
                if (Input.GetKeyDown(KeyCode.J))
                {
                    
                    Debug.Log("player current state" + playerCurrentState);
                    //if (playerModel.IsSeeingTarget && playerModel.Target != null)
                    //{
                    //    Debug.Log("Target in sight, looking at it and executing combo");
                    //    Vector3 dir = playerModel.Target.position - playerModel.transform.position; //lookdir
                    //    playerModel.LookDir(dir); //lookdir
                    //}
                    playerCurrentState++;
                    CheckComboAnim();
                    currentComboTimer = maxComboTimer;
                }
            }
            else
            {
                ResetCombo();
                playerModel.IsAttacking = false;
            }
        }

        public override void ExitState(EntityModel model)
        {
            Debug.Log("Exit");
            playerModel.IsAttacking = false;
            //playerModel.Controller.ResetAttackKeyCooldown();
        }

        void CheckComboAnim()
        {
            if (playerCurrentState == PlayerAttackComboState.PUNCH_1) playerModel.View.PlayerComboAttack1();
            else if (playerCurrentState == PlayerAttackComboState.PUNCH_2) playerModel.View.PlayerComboAttack2();
            else if (playerCurrentState == PlayerAttackComboState.PUNCH_3)
            {
                playerModel.View.PlayerComboAttack3();
                playerModel.IsAttacking = false;
            }

        }


        public void ResetCombo()
        {
            currentComboTimer = maxComboTimer;
            playerCurrentState = PlayerAttackComboState.NONE;
        }

    }
}
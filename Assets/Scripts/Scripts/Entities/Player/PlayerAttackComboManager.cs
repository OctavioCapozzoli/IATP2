using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Main.Scripts.Entities.Player;

public enum PlayerAttackComboState { NONE, PUNCH_1, PUNCH_2, PUNCH_3}
public class PlayerAttackComboManager
{
    [SerializeField] Animator playerAnim;
    PlayerView playerView;
    [SerializeField] float initComboCooldown = .5f;

    bool isComboReset;
    PlayerAttackComboState currentComboState;
    bool isEnabled;

    float currentComboCooldown;
    int keyPressCount = 0;
    float lastKeyPressTime = 0;

    public PlayerAttackComboManager(PlayerView _playerView, float _comboCooldown)
    {
        //playerAnim = _playerAnim;
        playerView = _playerView;
        initComboCooldown = _comboCooldown;

        InitComboState();
    }

    public bool IsEnabled { get => isEnabled; set => isEnabled = value; }

    public void InitComboState()
    {

        currentComboCooldown = initComboCooldown;
        currentComboState = PlayerAttackComboState.NONE;
        playerView.PlayerComboAttack1();
    }
    public void UpdateCombo()
    {

        ComboAttacks();
       // ResetComboState();

    }

    void ComboAttacks()
    {
        //Punch 
        if (isEnabled)
        {
            if (currentComboState == PlayerAttackComboState.PUNCH_3) return;


            Debug.Log(currentComboState);

            if (currentComboState == PlayerAttackComboState.PUNCH_1)
            {
                playerView.PlayerComboAttack1();
                currentComboState = PlayerAttackComboState.PUNCH_2;
            }
            else if (currentComboState == PlayerAttackComboState.PUNCH_2)
            {
                Debug.Log("2");
                playerView.PlayerComboAttack2();
            }
            else if (currentComboState == PlayerAttackComboState.PUNCH_3)
            {
                Debug.Log("3");
                playerView.PlayerComboAttack3();
            }

        }


    }

    void ResetComboState()
    {
        if (isComboReset)
        {
            //Debug.Log("Reset entered");
            currentComboCooldown -= Time.deltaTime;

            if (currentComboCooldown <= 0f)
            {

                currentComboState = PlayerAttackComboState.NONE;

                isComboReset = false;
                currentComboCooldown = initComboCooldown;

            }
        }
    }

        //private void Update()
        //{
        //    if (Time.time - lastKeyPressTime > initComboCooldown) keyPressCount = 0;

        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        lastKeyPressTime = Time.time;
        //        keyPressCount++;

        //        if (keyPressCount == 1)
        //            playerAnim.SetTrigger("onRegularAttack");
        //        keyPressCount = Mathf.Clamp(keyPressCount, 0, 3);
        //    }
        //}

        //public void ComboAttack2Transition()
        //{
        //    if (keyPressCount >= 2) playerAnim.SetTrigger("onRegAttackAnim2");
        //}
        //public void ComboAttack3Transition()
        //{
        //    if (keyPressCount >= 3) playerAnim.SetTrigger("onRegAttackAnim3");
        //}
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackComboManager : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] float comboCooldown = 1.2f;

    int keyPressCount = 0;
    float lastKeyPressTime = 0;

    private void Update()
    {
        if (Time.time - lastKeyPressTime > comboCooldown) keyPressCount = 0;

        if (Input.GetKeyDown(KeyCode.R))
        {
            lastKeyPressTime = Time.time;
            keyPressCount++;

            if (keyPressCount == 1)
                playerAnim.SetTrigger("onRegularAttack");
            keyPressCount = Mathf.Clamp(keyPressCount, 0, 3);
        }
    }

    public void ComboAttack2Transition()
    {
        if (keyPressCount >= 2) playerAnim.SetTrigger("onRegAttackAnim2");
    }
    public void ComboAttack3Transition()
    {
        if (keyPressCount >= 3) playerAnim.SetTrigger("onRegAttackAnim3");
    }
}

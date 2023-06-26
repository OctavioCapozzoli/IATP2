using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float target = 1;
    [SerializeField] private float reduceSpeed = 2;

    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        target = currentHealth / maxHealth;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
        _healthBar.fillAmount = Mathf.MoveTowards(_healthBar.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}

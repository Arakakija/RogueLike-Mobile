using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentHealth;
    [SerializeField] private TextMeshProUGUI _maxHealth;

    private void OnEnable()
    {
        PlayerController.Instance.Health.onHitEvent += UpdateCurrentHP;
        PlayerController.Instance.Health.onHealEvent += UpdateCurrentHP;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth.text = PlayerController.Instance.Health.CurrentHealth.ToString("F2");
        _maxHealth.text = PlayerController.Instance.Health.MaxHP.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCurrentHP(float currentHp)
    {
        _currentHealth.text = PlayerController.Instance.Health.CurrentHealth.ToString("F2");
    }
}

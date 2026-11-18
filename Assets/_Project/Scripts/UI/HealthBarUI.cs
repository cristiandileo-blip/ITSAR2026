using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Image barFill;
    [SerializeField] TMP_Text healthValueText;
    Health myHealth;

    private void Awake()
    {
        myHealth = GetComponentInParent<Health>(); 
    }

    private void OnEnable()
    {
        if (myHealth == null) myHealth = Health.playerHealth;
        myHealth.HealthChanged += UpdateBarValues;
    }

    private void OnDisable()
    {
        myHealth.HealthChanged -= UpdateBarValues;
    }

    void UpdateBarValues(float curHp, float maxHp)
    {
        barFill.fillAmount = curHp / maxHp;
        healthValueText.text = $"{curHp}/{maxHp}";
    }
}
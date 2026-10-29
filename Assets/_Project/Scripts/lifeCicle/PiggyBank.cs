using UnityEngine;
using System.Collections;
public class PiggyBank : MonoBehaviour
{

    [SerializeField] int maxCapacity = 50;
    [SerializeField] int currentValue;

    [SerializeField] BankAccount bankAccount;

    private void Awake()
    {
        currentValue = 0;
    }

    private void Start()
    {
        StartCoroutine(AddMoneyToPiggyBank());
    }

    IEnumerator AddMoneyToPiggyBank()
    {
        yield return new WaitForSeconds(1);
        currentValue++;
        if(currentValue == maxCapacity)
        {
            addToAccount();
        }
        
        StartCoroutine(AddMoneyToPiggyBank());

    }

    void addToAccount()
    {
        if (bankAccount)
        {
            bankAccount.AddToAccount(currentValue);
            Debug.Log($"MONEY IN THE BANK: {bankAccount.BankValue}");
            currentValue = 0;
        }
    }
}

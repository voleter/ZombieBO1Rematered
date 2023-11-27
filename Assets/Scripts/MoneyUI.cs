using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text moneyText;  // Reference to the UI text displaying money
    private int money = 0;

    void Start()
    {
        UpdateMoneyUI();
    }

    // Function to add money
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyUI();
    }

    // Function to update the money UI
    void UpdateMoneyUI()
    {
        moneyText.text = "Money: $" + money;
    }

    // Function to check if the player has enough money
    public bool HasEnoughMoney(int amount)
    {
        return money >= amount;
    }

    // Function to deduct money
    public void DeductMoney(int amount)
    {
        money -= amount;
        UpdateMoneyUI();
    }
}

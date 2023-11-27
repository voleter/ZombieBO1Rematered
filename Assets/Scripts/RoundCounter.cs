using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public Text roundText;
    private float currentTime = 30; 
    private int roundCounter = 1;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            StartNewRound();
        }
    }

    void UpdateUI()
    {
        timerText.text = $"Time Remaining: {Mathf.Ceil(currentTime)} seconds";
        roundText.text = $"Round {IntToRoman(roundCounter)}";
    }

    void StartNewRound()
    {
        roundCounter++;
        currentTime = 30; 
        UpdateUI();
    }

    string IntToRoman(int num)
    {
        if (num < 1 || num > 3999)
        {
            return num.ToString();
        }

        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        return thousands[num / 1000] + hundreds[(num % 1000) / 100] + tens[(num % 100) / 10] + ones[num % 10];
    }

}

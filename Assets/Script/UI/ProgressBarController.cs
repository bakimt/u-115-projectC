using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Image fill;
    public TextMeshProUGUI amount;
    public int currentValue, maxValue;

    void Start()
    {
        fill.fillAmount = Normalise();
        amount.text = $"{currentValue}/{maxValue}";
    }

    public void Add(int val)
    {
        currentValue += val;

        if (currentValue > maxValue) currentValue = maxValue;

        fill.fillAmount = Normalise();
        amount.text = $"{currentValue}/{maxValue}";
    }

    private float Normalise()
    {
        return (float)currentValue / maxValue;
    }
}

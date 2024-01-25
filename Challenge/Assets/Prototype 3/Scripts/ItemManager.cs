using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueCoins;

    private int valueCoin;

    public void GetCoins()
    {
        valueCoin += 100;

        valueCoins.text = valueCoin.ToString();
    }
}

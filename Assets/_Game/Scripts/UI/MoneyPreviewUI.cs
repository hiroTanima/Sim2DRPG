using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPreviewUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI moneyText;

    private void OnEnable()
    {
        PlayerInventory.OnCoinAdded += PlayerInventory_OnCoinAdded;
        PlayerInventory.OnCoinRemoved += PlayerInventory_OnCoinRemoved;
        UpdateUI();
    }

    private void PlayerInventory_OnCoinRemoved(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    private void OnDisable()
    {
        PlayerInventory.OnCoinAdded -= PlayerInventory_OnCoinAdded;
        PlayerInventory.OnCoinRemoved -= PlayerInventory_OnCoinRemoved;
    }

    private void PlayerInventory_OnCoinAdded(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        moneyText.text = PlayerInventory.Instance.playerCoins.ToString("0.00");
    }
}

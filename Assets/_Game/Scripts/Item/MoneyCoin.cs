using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCoin : MonoBehaviour
{
    [SerializeField] private float moneyAmount;

    private void OnEnable()
    {
        moneyAmount = Random.Range(0.1f, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
        if(inventory != null)
        {
            inventory.AddCoins(moneyAmount);
            gameObject.SetActive(false);
        }
    }
}

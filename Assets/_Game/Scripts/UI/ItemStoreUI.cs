using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemStoreUI : MonoBehaviour
{
    public SO_Item itemSO;
    [SerializeField] private TMPro.TextMeshProUGUI itemNameText;
    [SerializeField] private Image iconImage;
    [SerializeField] private TMPro.TextMeshProUGUI itemPriceText;
    [SerializeField] private Image moneyIconImage;

    private Button buyButton;
    public bool isBrought {  get; private set; }
    private void OnEnable()
    {
        buyButton = GetComponent<Button>();
        if (isBrought)
        {
            buyButton.onClick.AddListener(() => { EquipItem(this.itemSO); });
        }
        else
        {
            buyButton.onClick.AddListener(() => { BuyItem(this.itemSO); });
        }
        UpdateDisplay();
    }

    private void OnDisable()
    {
        if (isBrought)
        {
            buyButton.onClick.RemoveListener(() => { EquipItem(this.itemSO); });
        }
        else
        {
            buyButton.onClick.RemoveListener(() => { BuyItem(this.itemSO); });
        }
    }

    private void Start()
    {
        isBrought = false;
    }

    public void UpdateDisplay()
    {
        itemNameText.text = itemSO.itemName;
        iconImage.sprite = itemSO.itemIcon;
        if(!isBrought)
        itemPriceText.text = itemSO.itemPrice.ToString() + "$";
    }
    public void BuyItem(SO_Item soItem)
    {
        if (this.isBrought) return;
        if (PlayerInventory.Instance.CanRemoveCoins(soItem.itemPrice))
        {
            this.isBrought = true;
            itemPriceText.text = "Equip";
            buyButton.onClick.RemoveListener(() => { BuyItem(this.itemSO); });
            buyButton.onClick.AddListener(() => { EquipItem(this.itemSO); });
            moneyIconImage.gameObject.SetActive(false);
        }
    }

    public void EquipItem(SO_Item soItem)
    {
        if (!this.isBrought) return;
        SO_CharacterBody characterBody = PlayerInventory.Instance.GetCharacterBody();
        switch (soItem.itemType)
        {
            case ItemType.Body:
                characterBody.characterBodyParts[0].bodyPart = soItem;
                break;
            case ItemType.Hair:
                characterBody.characterBodyParts[1].bodyPart = soItem;
                break;
            case ItemType.Outfit:
                characterBody.characterBodyParts[2].bodyPart = soItem;
                break;
        }
        PlayerInventory.Instance.ChangeCharacterItem();
        Debug.Log($"The {soItem.itemName} should be equipped right now");
    }

}

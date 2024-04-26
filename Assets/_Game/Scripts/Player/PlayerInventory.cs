using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    public static event EventHandler OnCoinAdded;
    public static event EventHandler OnCoinRemoved;
    public float playerCoins {  get; private set; }
    public bool isMenuOpen { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        isMenuOpen = false;
    }

    public void AddCoins(float amount)
    {
        playerCoins += amount;
        OnCoinAdded?.Invoke(this, EventArgs.Empty);
    }

    public bool CanRemoveCoins(float amount)
    {
        if(amount > playerCoins)
        {
            return false;
        }else if (amount <= playerCoins)
        {
            playerCoins -= amount;
            OnCoinRemoved?.Invoke(this, EventArgs.Empty);
            return true;
        }
        return false;
    }

    public void ToggleIsMenuOpen()
    {
        isMenuOpen = !isMenuOpen;
    }

    private BodyPartManager GetBodyPartManager()
    {
        BodyPartManager bodyPartManager = gameObject.GetComponent<BodyPartManager>();
        return bodyPartManager;
    }

    public SO_CharacterBody GetCharacterBody()
    {
        return GetBodyPartManager().characterBody;
    }

    public void ChangeCharacterItem()
    {
        GetBodyPartManager().UpdateBodyParts();
    }

}

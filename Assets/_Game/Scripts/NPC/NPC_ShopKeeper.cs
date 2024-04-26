using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ShopKeeper : MonoBehaviour
{
    [SerializeField] private Transform dialogBox;
    [SerializeField] private Transform shopUI;

    private bool isOnRange = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            dialogBox.gameObject.SetActive(true);
            isOnRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            dialogBox.gameObject.SetActive(false);
            isOnRange = false;
        }
    }

    private void Update()
    {
        if (!isOnRange) { return; }
        if (Input.GetKeyDown(KeyCode.E) && !shopUI.gameObject.activeInHierarchy)
        {
            OpenShop();
        }
    }

    private void OpenShop()
    {
        PlayerInventory.Instance.ToggleIsMenuOpen();
        dialogBox.gameObject.SetActive(false);
        shopUI.gameObject.SetActive(true);
    }
}

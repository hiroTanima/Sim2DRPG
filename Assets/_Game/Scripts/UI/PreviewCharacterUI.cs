using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewCharacterUI : MonoBehaviour
{
    [SerializeField] private Image body;
    [SerializeField] private Image hair;
    [SerializeField] private Image outfit;
    private void Awake()
    {
        BodyPartManager.OnAnyPartChanged += BodyPartManager_OnAnyPartChanged;
        UpdateUI();
    }

    private void BodyPartManager_OnAnyPartChanged(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        SO_CharacterBody characterBody = PlayerInventory.Instance.GetCharacterBody();
        body.sprite = characterBody.characterBodyParts[0].bodyPart.itemIcon;
        hair.sprite = characterBody.characterBodyParts[1].bodyPart.itemIcon;
        outfit.sprite = characterBody.characterBodyParts[2].bodyPart.itemIcon;
    }
}

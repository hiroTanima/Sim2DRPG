using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyPartManager : MonoBehaviour
{
    const string BodyPart_Body = "Body";
    const string BodyPart_Hair = "Hair";
    const string BodyPart_Outfit = "Outfit";
    const string CharState_Idle = "Idle";
    const string CharState_Walk = "Walk";
    const string CharDirection_Down = "Down";
    const string CharDirection_Left = "Left";
    const string CharDirection_Right = "Right";
    const string CharDirection_Up = "Up";

    public static event EventHandler OnAnyPartChanged;
    public SO_CharacterBody characterBody;

    private string[] bodyPartTypes = { BodyPart_Body, BodyPart_Hair, BodyPart_Outfit };
    private string[] characterStates = { CharState_Idle, CharState_Walk };
    private string[] characterDirections = {CharDirection_Down, CharDirection_Left, CharDirection_Right,CharDirection_Up };

    private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides defaultAnimationClips;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        UpdateBodyParts();
    }

    public void UpdateBodyParts()
    {
        for (int partIndex = 0;partIndex<bodyPartTypes.Length;partIndex++)
        {
            string partType = bodyPartTypes[partIndex];
            string partID = characterBody.characterBodyParts[partIndex].bodyPart.itemIndex.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];
                    animationClip = Resources.Load<AnimationClip>($"Animations/{partType}/{partType}_{partID}_{state}_{direction}");
                    defaultAnimationClips[$"{partType}_0_{state}_{direction}"] = animationClip;
                }
            }
        }

        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
        OnAnyPartChanged?.Invoke(this, EventArgs.Empty);
    }
}

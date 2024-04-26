using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterBody", menuName = "ScriptableObjects/CharacterBody", order = 0)]
public class SO_CharacterBody : ScriptableObject
{
    public BodyPart[] characterBodyParts;
}

[System.Serializable]
public class BodyPart
{
    public string bodyPartName;
    public SO_Item bodyPart;
}


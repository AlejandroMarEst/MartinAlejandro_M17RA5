using UnityEngine;

public enum EquipmentSlot
{
    RightHand,
    LeftHand,
    Head,
    Body
}

[System.Serializable]
public class EquipmentPoint
{
    public EquipmentSlot slot;
    public Transform attachTransform;
}

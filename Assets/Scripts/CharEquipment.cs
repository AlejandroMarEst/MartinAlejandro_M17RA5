using System.Collections.Generic;
using UnityEngine;

public class CharEquipment : MonoBehaviour
{
    public EquipmentPoint[] equipmentPoints;
    private Dictionary<EquipmentSlot, GameObject> equippedObjects =
        new Dictionary<EquipmentSlot, GameObject>();
    public void Equip(EquippableItem item)
    {
        EquipmentSlot slot = SlotFromItemType(item.itemType);
        Transform attach = GetAttachTransform(slot);
        if (attach == null) return;
        if (equippedObjects.ContainsKey(slot))
        {
            Destroy(equippedObjects[slot]);
        }
        GameObject obj = Instantiate(item.prefab, attach);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        equippedObjects[slot] = obj;
    }

    EquipmentSlot SlotFromItemType(ItemType type)
    {
        switch (type)
        {
            case ItemType.Weapon: return EquipmentSlot.RightHand;
            case ItemType.Shield: return EquipmentSlot.LeftHand;
            case ItemType.Helmet: return EquipmentSlot.Head;
            case ItemType.Armor: return EquipmentSlot.Body;
            default: return EquipmentSlot.Body;
        }
    }

    Transform GetAttachTransform(EquipmentSlot slot)
    {
        foreach (var p in equipmentPoints)
        {
            if (p.slot == slot)
                return p.attachTransform;
        }
        return null;
    }
}

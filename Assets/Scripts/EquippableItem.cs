using UnityEngine;

public enum ItemType
{
    Weapon,
    Helmet,
    Armor,
    Shield
}

[CreateAssetMenu(menuName = "Items/Equippable Item")]
public class EquippableItem : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public GameObject prefab;
}

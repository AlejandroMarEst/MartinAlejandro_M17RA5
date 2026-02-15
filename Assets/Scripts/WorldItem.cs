using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public EquippableItem itemData;
    public void OnPickedUp(Player player)
    {
        var equipment = player.GetComponent<CharEquipment>();
        if (equipment != null)
        {
            equipment.Equip(itemData);
        }
        Destroy(gameObject);
    }
}

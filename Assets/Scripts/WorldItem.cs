using UnityEngine;

public class WorldItem : MonoBehaviour, IInteractable
{
    public EquippableItem itemData;
    public void Interact(Player player)
    {
        OnPickedUp(player);
    }
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

using UnityEngine;

public class Campfire : MonoBehaviour, IInteractable
{
    [SerializeField] private GameManager gameManager;
    public void Interact(Player player)
    {
        gameManager.SaveGame();
    }
}

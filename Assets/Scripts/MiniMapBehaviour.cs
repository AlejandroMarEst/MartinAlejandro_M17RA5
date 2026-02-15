using UnityEngine;

public class MiniMapBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private void LateUpdate()
    {
        Vector3 newPosition = _player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90f, 0f, -_player.eulerAngles.y +180f);
    }
}

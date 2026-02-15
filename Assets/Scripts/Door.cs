using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float speed = 2f;

    bool isOpen;
    Quaternion closedDoor;
    Quaternion openDoor;

    void Start()
    {
        closedDoor = transform.rotation;
        openDoor = Quaternion.Euler(0, openAngle, 0) * transform.rotation;
    }

    public void Interact(Player player)
    {
        StopAllCoroutines();
        StartCoroutine(RotateDoor());
    }

    System.Collections.IEnumerator RotateDoor()
    {
        Quaternion target = isOpen ? closedDoor : openDoor;
        Quaternion start = transform.rotation;
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * speed;
            transform.rotation = Quaternion.Slerp(start, target, time);
            yield return null;
        }
        isOpen = !isOpen;
    }
}

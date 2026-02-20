using System.IO;
using UnityEditor.Overlays;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EquippableItem[] itemsEquipped;
    [SerializeField] private Player player;
    [SerializeField] private CharacterController characterController;
    private string _saveFilePath;

    private void Awake()
    {
        _saveFilePath = Application.persistentDataPath + "/savefile.json";
    }
    private void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.playerPosition = player.transform.position;
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(_saveFilePath, json);
    }

    public void LoadGame()
    {
        if (File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            characterController.enabled = false;
            player.transform.position = saveData.playerPosition;
            characterController.enabled = true;
        }
    }
}
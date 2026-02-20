using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public List<EquipmentSaveData> equipment = new List<EquipmentSaveData>();
}

[Serializable]
public class EquipmentSaveData
{
    public EquipmentSlot slot;
    public string itemID;
}